using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Answer.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Answer.OperationRequestHandler
{
    class GetHexagramEntranceSoulRequestHandler : OperationRequestHandler<TerminalEndPoint, VirtualAnswer, AnswerOperationCode>
    {
        public GetHexagramEntranceSoulRequestHandler() : base(typeof(GetHexagramEntranceSoulRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint terminal, VirtualAnswer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            AnswerOperationResponseApi.SendEndPointOperationResponse(terminal, target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, VirtualAnswer requester, AnswerOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)GetHexagramEntranceSoulRequestParameterCode.SoulId];
                OperationReturnCode returnCode = requester.GetWillSoul(terminal.EndPointId, soulId, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
