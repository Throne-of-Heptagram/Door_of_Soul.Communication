using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Avatar
{
    class AvatarEventRouter : EventRouter<VirtualAvatar, AvatarEventCode>
    {
        public static AvatarEventRouter Instance { get; private set; } = new AvatarEventRouter();

        private AvatarEventRouter()
        {
        }
    }
}
