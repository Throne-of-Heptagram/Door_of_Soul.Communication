﻿using Door_of_Soul.Communication.Protocol.External.Avatar;

namespace Door_of_Soul.Communication.ProxyServer.Avatar
{
    class AvatarOperationRequestRouter : OperationRequestRouter<TerminalDevice, Core.Avatar, AvatarOperationCode>
    {
        public static AvatarOperationRequestRouter Instance { get; private set; } = new AvatarOperationRequestRouter();

        private AvatarOperationRequestRouter()
        {

        }
    }
}
