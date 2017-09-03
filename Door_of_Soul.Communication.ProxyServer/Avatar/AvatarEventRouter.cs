using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.Avatar
{
    class AvatarEventRouter : EventRouter<VirtualAvatar, AvatarEventCode>
    {
        public static AvatarEventRouter Instance { get; private set; } = new AvatarEventRouter();

        private AvatarEventRouter()
        {
        }
    }
}
