using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Communication.Protocol.Hexagram.Will.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will.OperationRequestHandler
{
    class GetWillSoulRequestHandler : OperationRequestHandler<TerminalHexagramEntrance<WillEventCode, WillOperationCode>, VirtualWill, WillOperationCode>
    {
        public GetWillSoulRequestHandler() : base(typeof(GetWillSoulRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalHexagramEntrance<WillEventCode, WillOperationCode> terminal, VirtualWill target, WillOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            WillOperationResponseApi.SendOperationResponse(terminal as WillHexagramEntrance, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalHexagramEntrance<WillEventCode, WillOperationCode> terminal, VirtualWill requester, WillOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)GetWillSoulRequestParameterCode.SoulId];
                OperationReturnCode returnCode = requester.GetWillSoul(terminal.HexagramEntranceId, soulId, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
