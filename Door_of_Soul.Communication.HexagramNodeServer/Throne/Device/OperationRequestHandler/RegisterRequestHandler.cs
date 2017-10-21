using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.Device.OperationRequestHandler
{
    class RegisterRequestHandler : L3SubjectOperationRequestHandler<ThroneHexagramEntrance, int, int, VirtualThrone>
    {
        public RegisterRequestHandler() : base(typeof(RegisterRequestParameterCode))
        {
        }

        public override void SendResponse(ThroneHexagramEntrance terminal, int subterminalId, int endTerminalId, VirtualThrone target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.DeviceOperationResponse(terminal, subterminalId, endTerminalId, DeviceThroneOperationCode.Register, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(ThroneHexagramEntrance terminal, int subterminalId, int endTerminalId, VirtualThrone requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, subterminalId, endTerminalId, requester, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                string answerName = (string)parameters[(byte)RegisterRequestParameterCode.AnswerName];
                string basicPassword = (string)parameters[(byte)RegisterRequestParameterCode.BasicPassword];
                returnCode = requester.DeviceRegister(terminal.HexagramEntranceId, subterminalId, endTerminalId, answerName, basicPassword, out errorMessage);
            }
            return returnCode;
        }
    }
}
