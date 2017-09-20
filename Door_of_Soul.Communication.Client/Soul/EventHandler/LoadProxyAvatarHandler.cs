using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.Soul.EventParameter;
using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Soul.EventHandler
{
    class LoadProxyAvatarHandler : EventHandler<VirtualSoul, SoulEventCode>
    {
        public LoadProxyAvatarHandler() : base(typeof(LoadProxyAvatarParameterCode))
        {
        }

        public override bool Handle(VirtualSoul subject, SoulEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                int avatarId = (int)parameters[(byte)LoadProxyAvatarParameterCode.AvatarId];
                int entityId = (int)parameters[(byte)LoadProxyAvatarParameterCode.EntityId];
                string avatarName = (string)parameters[(byte)LoadProxyAvatarParameterCode.AvatarName];
                int[] soulIds = (int[])parameters[(byte)LoadProxyAvatarParameterCode.SoulIds];
                subject.LoadProxyAvatar(avatarId, entityId, avatarName, soulIds);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
