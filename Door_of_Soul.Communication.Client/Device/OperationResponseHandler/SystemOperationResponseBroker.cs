using Door_of_Soul.Communication.Client.System;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.OperationResponseHandler
{
    class SystemOperationResponseBroker : BasicOperationResponseHandler
    {
        public SystemOperationResponseBroker() : base(typeof(SystemOperationResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                SystemOperationCode resolvedOperationCode = (SystemOperationCode)parameters[(byte)SystemOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)SystemOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)SystemOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SystemOperationResponseParameterCode.Parameters];
                returnCode = SystemOperationResponseRouter.Instance.Route(VirtualSystem.Instance, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
            }
            return returnCode;
        }
    }
}
