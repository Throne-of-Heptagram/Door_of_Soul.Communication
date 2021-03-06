﻿using Door_of_Soul.Communication.HexagramEntranceServer.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class DeviceAnswerOperationRequestBroker : OperationRequestHandler<TerminalEndPoint, EndPointOperationCode>
    {
        public DeviceAnswerOperationRequestBroker() : base(typeof(DeviceAnswerOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint target, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)DeviceAnswerOperationRequestParameterCode.DeviceId];
                int answerId = (int)parameters[(byte)DeviceAnswerOperationRequestParameterCode.AnswerId];
                AnswerOperationCode resolvedOperationCode = (AnswerOperationCode)parameters[(byte)DeviceAnswerOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceAnswerOperationRequestParameterCode.Parameters];
                VirtualAnswer answer;
                if (ResourceService.Instance.FindAnswer(answerId, out answer))
                {
                    return AnswerOperationRequestRouter.Instance.Route(terminal, deviceId, answer, resolvedOperationCode, resolvedParameters, out errorMessage);
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
