using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.OperationResponseParameter;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.System.OperationResponseHandler
{
    class LoginResponseHandler : SubjectOperationResponseHandler<VirtualSystem, SystemOperationCode>
    {
        public LoginResponseHandler() : base(typeof(LoginResponseParameterCode))
        {
        }

        public override bool Handle(VirtualSystem subject, SystemOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                string trinityServerAddress = (string)parameters[(byte)LoginResponseParameterCode.TrinityServerAddress];
                int trinityServerPort = (int)parameters[(byte)LoginResponseParameterCode.TrinityServerPort];
                string trinityServerApplicationName = (string)parameters[(byte)LoginResponseParameterCode.TrinityServerApplicationName];
                int answerId = (int)parameters[(byte)LoginResponseParameterCode.AnswerId];
                string answerAccessToken = (string)parameters[(byte)LoginResponseParameterCode.AnswerAccessToken];
                subject.LoginResponse(returnCode, operationMessage, trinityServerAddress, trinityServerPort, trinityServerApplicationName, answerId, answerAccessToken);
                return true;
            }
            else
            {
                subject.LoginResponse(returnCode, operationMessage, default(string), default(int), default(string), default(int), default(string));
                return false;
            }
        }
    }
}
