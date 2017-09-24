using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.LoginServer.System;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.LoginServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.EndPoint.OperationResponseHandler
{
    class SystemOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public SystemOperationResponseBroker() : base(typeof(SystemOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                SystemOperationCode resolvedOperationCode = (SystemOperationCode)parameters[(byte)SystemOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)SystemOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)SystemOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SystemOperationResponseParameterCode.Parameters];
                return SystemOperationResponseRouter.Instance.Route(VirtualSystem.Instance, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
