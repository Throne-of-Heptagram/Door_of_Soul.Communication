using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System.OperationRequestHandler
{
    class DeviceRegisterRequestHandler : L2SubjectOperationRequestHandler<TerminalEndPoint, int, VirtualSystem>
    {
        public DeviceRegisterRequestHandler() : base(typeof(DeviceRegisterRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint terminal, int l2TerminalId, VirtualSystem target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendDeviceOperationResponse(terminal, l2TerminalId, SystemOperationCode.DeviceRegister, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalEndPoint terminal, int l2TerminalId, VirtualSystem requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, l2TerminalId, requester, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                string answerName = (string)parameters[(byte)DeviceRegisterRequestParameterCode.AnswerName];
                string basicPassword = (string)parameters[(byte)DeviceRegisterRequestParameterCode.BasicPassword];
                returnCode = requester.DeviceRegister(terminal.EndPointId, l2TerminalId, answerName, basicPassword, out errorMessage);
            }
            return returnCode;
        }
    }
}
