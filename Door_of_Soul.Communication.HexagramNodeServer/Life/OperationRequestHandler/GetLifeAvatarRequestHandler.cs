using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Communication.Protocol.Hexagram.Life.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life.OperationRequestHandler
{
    class GetLifeAvatarRequestHandler : OperationRequestHandler<TerminalHexagramEntrance<LifeEventCode, LifeOperationCode>, VirtualLife, LifeOperationCode>
    {
        public GetLifeAvatarRequestHandler() : base(typeof(GetLifeAvatarRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalHexagramEntrance<LifeEventCode, LifeOperationCode> terminal, VirtualLife target, LifeOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            LifeOperationResponseApi.SendOperationResponse(terminal as LifeHexagramEntrance, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalHexagramEntrance<LifeEventCode, LifeOperationCode> terminal, VirtualLife requester, LifeOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)GetLifeAvatarRequestParameterCode.AvatarId];
                OperationReturnCode returnCode = requester.GetLifeAvatar(terminal.HexagramEntranceId, avatarId, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
