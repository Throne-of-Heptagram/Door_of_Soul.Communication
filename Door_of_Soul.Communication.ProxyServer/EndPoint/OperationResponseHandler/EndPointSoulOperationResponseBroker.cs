using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.ProxyServer.Soul;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint.OperationResponseHandler
{
    class EndPointSoulOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public EndPointSoulOperationResponseBroker() : base(typeof(EndPointSoulOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)EndPointSoulOperationResponseParameterCode.SoulId];
                SoulOperationCode resolvedOperationCode = (SoulOperationCode)parameters[(byte)EndPointSoulOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)EndPointSoulOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)EndPointSoulOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointSoulOperationResponseParameterCode.Parameters];
                VirtualSoul soul;
                if (ResourceService.Instance.FindSoul(soulId, out soul))
                {
                    return SoulOperationResponseRouter.Instance.Route(soul, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
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
