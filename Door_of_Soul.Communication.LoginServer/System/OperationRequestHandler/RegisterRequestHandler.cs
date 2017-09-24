using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.OperationRequestParameter;
using Door_of_Soul.Core.LoginServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System.OperationRequestHandler
{
    class RegisterRequestHandler : SubjectOperationRequestHandler<TerminalDevice, VirtualSystem, SystemOperationCode>
    {
        public RegisterRequestHandler() : base(typeof(RegisterRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice terminal, VirtualSystem target, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalDevice terminal, VirtualSystem requester, SystemOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if(base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                string answerName = (string)parameters[(byte)RegisterRequestParameterCode.AnswerName];
                string basicPassword = (string)parameters[(byte)RegisterRequestParameterCode.BasicPassword];
                OperationReturnCode returnCode = requester.Register(terminal.DeviceId, answerName, basicPassword, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
