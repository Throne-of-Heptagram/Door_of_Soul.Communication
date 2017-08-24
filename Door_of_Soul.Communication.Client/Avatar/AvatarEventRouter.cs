using Door_of_Soul.Communication.Protocol.External.Avatar;

namespace Door_of_Soul.Communication.Client.Avatar
{
    class AvatarEventRouter : EventRouter<Core.Avatar, AvatarEventCode>
    {
        public static AvatarEventRouter Instance { get; private set; } = new AvatarEventRouter();

        private AvatarEventRouter()
        {
        }
    }
}
