using Door_of_Soul.Communication.Protocol.Internal.Avatar;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.Avatar
{
    class AvatarOperationRequestRouter : OperationRequestRouter<Core.Internal.EndPoint, int, Core.Avatar, AvatarOperationCode>
    {
        public static AvatarOperationRequestRouter Instance { get; private set; } = new AvatarOperationRequestRouter();

        private AvatarOperationRequestRouter()
        {

        }
    }
}
