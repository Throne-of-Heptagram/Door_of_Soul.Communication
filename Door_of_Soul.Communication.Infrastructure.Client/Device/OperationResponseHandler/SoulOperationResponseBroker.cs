using Door_of_Soul.Communication.Infrastructure.Client.Soul;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.OperationResponseHandler
{
    class SoulOperationResponseBroker : OperationResponseHandler<Core.Device, DeviceOperationCode>
    {
        public SoulOperationResponseBroker() : base(typeof(SoulOperationResponseParameterCode))
        {
        }

        internal override bool Handle(Core.Device subject, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)SoulOperationResponseParameterCode.SoulId];
                SoulOperationCode soulOperationCode = (SoulOperationCode)parameters[(byte)SoulOperationResponseParameterCode.OperationCode];
                OperationReturnCode soulOperationReturnCode = (OperationReturnCode)parameters[(byte)SoulOperationResponseParameterCode.OperationReturnCode];
                string soulOperationMessage = (string)parameters[(byte)SoulOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)SoulOperationResponseParameterCode.Parameters];
                Core.Soul soul;
                if (CommunicationService.Instance.FindSoul(soulId, out soul))
                {
                    return SoulOperationResponseRouter.Instance.Route(soul, soulOperationCode, soulOperationReturnCode, soulOperationMessage, operationResponseParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SoulId:{soulId}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
