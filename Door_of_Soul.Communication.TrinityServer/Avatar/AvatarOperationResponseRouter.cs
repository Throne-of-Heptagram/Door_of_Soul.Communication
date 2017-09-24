using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.Avatar
{
    class AvatarOperationResponseRouter : SubjectOperationResponseRouter<VirtualAvatar, AvatarOperationCode>
    {
        public static AvatarOperationResponseRouter Instance { get; private set; } = new AvatarOperationResponseRouter();

        private AvatarOperationResponseRouter() : base("TrinityServerAvatar")
        {
        }
    }
}
