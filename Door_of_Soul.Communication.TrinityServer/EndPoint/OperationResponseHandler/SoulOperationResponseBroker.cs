using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.TrinityServer.Soul;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.OperationResponseHandler
{
    class SoulOperationResponseBroker : BasicOperationResponseHandler
    {
        public SoulOperationResponseBroker() : base(typeof(SoulOperationResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int soulId = (int)parameters[(byte)SoulOperationResponseParameterCode.SoulId];
                SoulOperationCode resolvedOperationCode = (SoulOperationCode)parameters[(byte)SoulOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)SoulOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)SoulOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SoulOperationResponseParameterCode.Parameters];
                VirtualSoul soul;
                if (ResourceService.Instance.FindSoul(soulId, out soul))
                {
                    returnCode = SoulOperationResponseRouter.Instance.Route(soul, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SoulId:{soulId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
