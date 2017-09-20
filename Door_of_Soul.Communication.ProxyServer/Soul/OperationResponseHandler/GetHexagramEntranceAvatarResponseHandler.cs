using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.Soul.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Soul.OperationResponseHandler
{
    class GetHexagramEntranceAvatarResponseHandler : OperationResponseHandler<VirtualSoul, SoulOperationCode>
    {
        public GetHexagramEntranceAvatarResponseHandler() : base(typeof(GetHexagramEntranceAvatarResponseParameterCode))
        {
        }

        public override bool Handle(VirtualSoul subject, SoulOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)GetHexagramEntranceAvatarResponseParameterCode.AvatarId];
                int entityId = (int)parameters[(byte)GetHexagramEntranceAvatarResponseParameterCode.EntityId];
                string avatarName = (string)parameters[(byte)GetHexagramEntranceAvatarResponseParameterCode.AvatarName];
                int[] soulIds = (int[])parameters[(byte)GetHexagramEntranceAvatarResponseParameterCode.SoulIds];
                subject.GetHexagramEntranceAvatarResponse(returnCode, operationMessage, avatarId, entityId, avatarName, soulIds);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
