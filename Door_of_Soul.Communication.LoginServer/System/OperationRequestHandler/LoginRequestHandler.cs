using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.OperationRequestParameter;
using Door_of_Soul.Core.LoginServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System.OperationRequestHandler
{
    class LoginRequestHandler : SubjectOperationRequestHandler<TerminalDevice, VirtualSystem>
    {
        public LoginRequestHandler() : base(typeof(LoginRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice terminal, VirtualSystem target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendOperationResponse(terminal, SystemOperationCode.Login, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalDevice terminal, VirtualSystem requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, requester, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                string answerName = (string)parameters[(byte)RegisterRequestParameterCode.AnswerName];
                string basicPassword = (string)parameters[(byte)RegisterRequestParameterCode.BasicPassword];
                returnCode = requester.Login(terminal.DeviceId, answerName, basicPassword, out errorMessage);
                if(returnCode != OperationReturnCode.Successiful)
                {
                    SendResponse(terminal, requester, returnCode, errorMessage, new Dictionary<byte, object>());
                }
            }
            return returnCode;
        }
    }
}
