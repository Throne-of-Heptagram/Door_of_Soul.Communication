using Door_of_Soul.Communication.Protocol.External.Avatar;

namespace Door_of_Soul.Communication.Infrastructure.Client.Avatar
{
    class AvatarOperationResponseRouter : OperationResponseRouter<Core.Avatar, AvatarOperationCode>
    {
        public static AvatarOperationResponseRouter Instance { get; private set; } = new AvatarOperationResponseRouter();

        private AvatarOperationResponseRouter()
        {
        }
    }
}
