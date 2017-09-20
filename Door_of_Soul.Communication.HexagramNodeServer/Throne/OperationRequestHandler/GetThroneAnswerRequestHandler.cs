using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.OperationRequestHandler
{
    class GetThroneAnswerRequestHandler : OperationRequestHandler<TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode>, VirtualThrone, ThroneOperationCode>
    {
        public GetThroneAnswerRequestHandler() : base(typeof(GetThroneAnswerRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode> terminal, VirtualThrone target, ThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.SendOperationResponse(terminal as ThroneHexagramEntrance, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode> terminal, VirtualThrone requester, ThroneOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)GetThroneAnswerRequestParameterCode.AnswerId];
                OperationReturnCode returnCode = requester.GetThroneAnswer(terminal.HexagramEntranceId, answerId, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
