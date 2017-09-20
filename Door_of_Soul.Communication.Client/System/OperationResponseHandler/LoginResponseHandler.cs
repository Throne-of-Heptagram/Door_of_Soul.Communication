using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.OperationResponseParameter;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.System.OperationResponseHandler
{
    class LoginResponseHandler : OperationResponseHandler<VirtualSystem, SystemOperationCode>
    {
        public LoginResponseHandler() : base(typeof(LoginResponseParameterCode))
        {
        }

        public override bool Handle(VirtualSystem subject, SystemOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                subject.LoginResponse(returnCode, operationMessage);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
