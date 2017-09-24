using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.Avatar
{
    class AvatarEventRouter : SubjectEventRouter<VirtualAvatar, AvatarEventCode>
    {
        public static AvatarEventRouter Instance { get; private set; } = new AvatarEventRouter();

        private AvatarEventRouter() : base("TrinityServerAvatar")
        {
        }
    }
}
