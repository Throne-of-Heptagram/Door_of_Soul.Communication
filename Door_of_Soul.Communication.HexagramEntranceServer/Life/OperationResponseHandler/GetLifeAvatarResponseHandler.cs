using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Communication.Protocol.Hexagram.Life.OperationResponseParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Life.OperationResponseHandler
{
    class GetLifeAvatarResponseHandler : OperationResponseHandler<LifeOperationCode>
    {
        public GetLifeAvatarResponseHandler() : base(typeof(GetLifeAvatarResponseParameterCode))
        {
        }

        public override bool Handle(LifeOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)GetLifeAvatarResponseParameterCode.AvatarId];
                int entityId = (int)parameters[(byte)GetLifeAvatarResponseParameterCode.EntityId];
                string avatarName = (string)parameters[(byte)GetLifeAvatarResponseParameterCode.AvatarName];
                int[] soulIds = (int[])parameters[(byte)GetLifeAvatarResponseParameterCode.SoulIds];
                for(int i = 0; i < soulIds.Length; i++)
                {
                    VirtualSoul soul;
                    if (ResourceService.Instance.FindSoul(soulIds[i], out soul))
                    {
                        soul.GetLifeAvatarResponse(returnCode, operationMessage, avatarId, entityId, avatarName, soulIds);
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
