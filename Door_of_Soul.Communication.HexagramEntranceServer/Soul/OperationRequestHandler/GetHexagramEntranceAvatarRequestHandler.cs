using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.Soul.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Soul.OperationRequestHandler
{
    class GetHexagramEntranceAvatarRequestHandler : OperationRequestHandler<TerminalEndPoint, VirtualSoul, SoulOperationCode>
    {
        public GetHexagramEntranceAvatarRequestHandler() : base(typeof(GetHexagramEntranceAvatarRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint terminal, VirtualSoul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SoulOperationResponseApi.SendEndPointOperationResponse(terminal, target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, VirtualSoul requester, SoulOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)GetHexagramEntranceAvatarRequestParameterCode.AvatarId];
                OperationReturnCode returnCode = requester.GetLifeAvatar(terminal.EndPointId, avatarId, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
