using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.OperationRequestParameter;
using Door_of_Soul.Core.LoginServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System.OperationRequestHandler
{
    class LoginRequestHandler : SubjectOperationRequestHandler<TerminalDevice, VirtualSystem, SystemOperationCode>
    {
        public LoginRequestHandler() : base(typeof(LoginRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice terminal, VirtualSystem target, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalDevice terminal, VirtualSystem requester, SystemOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                string answerName = (string)parameters[(byte)RegisterRequestParameterCode.AnswerName];
                string basicPassword = (string)parameters[(byte)RegisterRequestParameterCode.BasicPassword];
                OperationReturnCode returnCode = requester.Login(terminal.DeviceId, answerName, basicPassword, out errorMessage);
                if(returnCode != OperationReturnCode.Successiful)
                {
                    SendResponse(terminal, requester, operationCode, returnCode, errorMessage, new Dictionary<byte, object>());
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
