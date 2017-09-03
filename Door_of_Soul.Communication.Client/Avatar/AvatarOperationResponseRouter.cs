using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Avatar
{
    class AvatarOperationResponseRouter : OperationResponseRouter<VirtualAvatar, AvatarOperationCode>
    {
        public static AvatarOperationResponseRouter Instance { get; private set; } = new AvatarOperationResponseRouter();

        private AvatarOperationResponseRouter()
        {
        }
    }
}
