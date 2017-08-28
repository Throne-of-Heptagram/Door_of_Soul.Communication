using Door_of_Soul.Communication.Protocol.Internal.Avatar;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Avatar
{
    class AvatarOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, int, Core.Avatar, AvatarOperationCode>
    {
        public static AvatarOperationRequestRouter Instance { get; private set; } = new AvatarOperationRequestRouter();

        private AvatarOperationRequestRouter()
        {

        }
    }
}
