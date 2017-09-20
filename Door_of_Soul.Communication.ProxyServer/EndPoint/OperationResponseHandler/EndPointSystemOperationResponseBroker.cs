using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.ProxyServer.System;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint.OperationResponseHandler
{
    class EndPointSystemOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public EndPointSystemOperationResponseBroker() : base(typeof(EndPointSystemOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                SystemOperationCode resolvedOperationCode = (SystemOperationCode)parameters[(byte)EndPointSystemOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)EndPointSystemOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)EndPointSystemOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointSystemOperationResponseParameterCode.Parameters];
                return SystemOperationResponseRouter.Instance.Route(VirtualSystem.Instance, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
