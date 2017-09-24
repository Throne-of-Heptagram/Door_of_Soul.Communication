using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System.OperationRequestHandler
{
    class DeviceRegisterRequestHandler : L2SubjectOperationRequestHandler<TerminalEndPoint, int, VirtualSystem, SystemOperationCode>
    {
        public DeviceRegisterRequestHandler() : base(typeof(DeviceRegisterRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint terminal, int subterminalId, VirtualSystem target, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendDeviceOperationResponse(terminal, subterminalId, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, int subterminalId, VirtualSystem requester, SystemOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, subterminalId, requester, operationCode, parameters, out errorMessage))
            {
                string answerName = (string)parameters[(byte)DeviceRegisterRequestParameterCode.AnswerName];
                string basicPassword = (string)parameters[(byte)DeviceRegisterRequestParameterCode.BasicPassword];
                OperationReturnCode returnCode = requester.DeviceRegister(terminal.EndPointId, subterminalId, answerName, basicPassword, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
