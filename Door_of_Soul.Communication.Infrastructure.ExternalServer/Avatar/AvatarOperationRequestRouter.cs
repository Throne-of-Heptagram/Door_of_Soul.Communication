﻿using Door_of_Soul.Communication.Protocol.External.Avatar;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Avatar
{
    class AvatarOperationRequestRouter : OperationRequestRouter<Core.Device, Core.Avatar, AvatarOperationCode>
    {
        public static AvatarOperationRequestRouter Instance { get; private set; } = new AvatarOperationRequestRouter();

        private AvatarOperationRequestRouter()
        {

        }
    }
}
