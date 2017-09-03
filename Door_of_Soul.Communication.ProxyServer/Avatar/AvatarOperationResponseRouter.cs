using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.Avatar
{
    class AvatarOperationResponseRouter : OperationResponseRouter<VirtualAvatar, AvatarOperationCode>
    {
        public static AvatarOperationResponseRouter Instance { get; private set; } = new AvatarOperationResponseRouter();

        private AvatarOperationResponseRouter()
        {
        }
    }
}
