using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.Device.OperationRequestHandler
{
    class RegisterRequestHandler : L3SubjectOperationRequestHandler<ThroneHexagramEntrance, int, int, VirtualThrone, DeviceThroneOperationCode>
    {
        public RegisterRequestHandler() : base(typeof(RegisterRequestParameterCode))
        {
        }

        public override void SendResponse(ThroneHexagramEntrance terminal, int subterminalId, int endTerminalId, VirtualThrone target, DeviceThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.DeviceOperationResponse(terminal, subterminalId, endTerminalId, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(ThroneHexagramEntrance terminal, int subterminalId, int endTerminalId, VirtualThrone requester, DeviceThroneOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, subterminalId, endTerminalId, requester, operationCode, parameters, out errorMessage))
            {
                string answerName = (string)parameters[(byte)RegisterRequestParameterCode.AnswerName];
                string basicPassword = (string)parameters[(byte)RegisterRequestParameterCode.BasicPassword];
                OperationReturnCode returnCode = requester.DeviceRegister(terminal.HexagramEntranceId, subterminalId, endTerminalId, answerName, basicPassword, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
