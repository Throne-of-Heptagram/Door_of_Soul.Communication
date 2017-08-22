﻿using Door_of_Soul.Communication.Protocol.Internal.Avatar;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Avatar
{
    class AvatarEventRouter : EventRouter<Core.Avatar, AvatarEventCode>
    {
        public static AvatarEventRouter Instance { get; private set; } = new AvatarEventRouter();

        private AvatarEventRouter()
        {
        }
    }
}
