using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.Avatar
{
    class AvatarOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, VirtualAvatar, AvatarOperationCode>
    {
        public static AvatarOperationRequestRouter Instance { get; private set; } = new AvatarOperationRequestRouter();

        private AvatarOperationRequestRouter() : base("TrinityServerAvatar")
        {

        }
    }
}
