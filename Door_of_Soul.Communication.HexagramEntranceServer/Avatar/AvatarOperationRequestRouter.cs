﻿using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Avatar
{
    class AvatarOperationRequestRouter : L2SubjectOperationRequestRouter<TerminalEndPoint, int, VirtualAvatar, AvatarOperationCode>
    {
        public static AvatarOperationRequestRouter Instance { get; private set; } = new AvatarOperationRequestRouter();

        private AvatarOperationRequestRouter() : base("HexagramEntranceServerAvatar")
        {

        }
    }
}
