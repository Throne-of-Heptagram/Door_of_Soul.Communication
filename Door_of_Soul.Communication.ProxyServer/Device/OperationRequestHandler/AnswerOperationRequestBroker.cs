﻿using Door_of_Soul.Communication.ProxyServer.Answer;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Device.OperationRequestHandler
{
    class AnswerOperationRequestBroker : OperationRequestHandler<TerminalDevice, TerminalDevice, DeviceOperationCode>
    {
        public AnswerOperationRequestBroker() : base(typeof(AnswerOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice terminal, TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalDevice terminal, TerminalDevice requester, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)AnswerOperationRequestParameterCode.AnswerId];
                AnswerOperationCode answerOperationCode = (AnswerOperationCode)parameters[(byte)AnswerOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)AnswerOperationRequestParameterCode.Parameters];
                if (requester.IsAnswerLinked(answerId))
                {
                    return AnswerOperationRequestRouter.Instance.Route(terminal, requester.Answer, answerOperationCode, operationRequestParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find AnswerId:{answerId}";
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