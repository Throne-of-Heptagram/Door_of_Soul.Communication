using Door_of_Soul.Communication.Protocol.Internal.Avatar;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Avatar
{
    class AvatarOperationResponseRouter : OperationResponseRouter<Core.Internal.EndPoint, Core.Avatar, AvatarOperationCode>
    {
        public static AvatarOperationResponseRouter Instance { get; private set; } = new AvatarOperationResponseRouter();

        private AvatarOperationResponseRouter()
        {
        }
    }
}
