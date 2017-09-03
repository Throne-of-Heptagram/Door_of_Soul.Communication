using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.Avatar
{
    class AvatarOperationRequestRouter : OperationRequestRouter<TerminalDevice, VirtualAvatar, AvatarOperationCode>
    {
        public static AvatarOperationRequestRouter Instance { get; private set; } = new AvatarOperationRequestRouter();

        private AvatarOperationRequestRouter()
        {

        }
    }
}
