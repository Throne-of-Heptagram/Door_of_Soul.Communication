using Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint.OperationResponseHandler
{
    class SoulOperationResponseBroker : OperationResponseHandler<Core.InternalServer.EndPoint, Core.InternalServer.EndPoint, EndPointOperationCode>
    {
        public SoulOperationResponseBroker() : base(typeof(SoulOperationResponseParameterCode))
        {
        }

        public override bool Handle(Core.InternalServer.EndPoint terminal, Core.InternalServer.EndPoint subject, EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)SoulOperationResponseParameterCode.SoulId];
                SoulOperationCode soulOperationCode = (SoulOperationCode)parameters[(byte)SoulOperationResponseParameterCode.OperationCode];
                OperationReturnCode soulOperationReturnCode = (OperationReturnCode)parameters[(byte)SoulOperationResponseParameterCode.OperationReturnCode];
                string soulOperationMessage = (string)parameters[(byte)SoulOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)SoulOperationResponseParameterCode.Parameters];
                Core.Soul soul;
                if (CommunicationService.Instance.FindSoul(soulId, out soul))
                {
                    return SoulOperationResponseRouter.Instance.Route(terminal, soul, soulOperationCode, soulOperationReturnCode, soulOperationMessage, operationResponseParameters, out errorMessage);
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
