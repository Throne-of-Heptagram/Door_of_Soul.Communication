using Door_of_Soul.Communication.Protocol.Internal.Soul;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul
{
    class SoulOperationRequestRouter : OperationRequestRouter<Core.Internal.EndPoint, int, Core.Soul, SoulOperationCode>
    {
        public static SoulOperationRequestRouter Instance { get; private set; } = new SoulOperationRequestRouter();

        private SoulOperationRequestRouter()
        {

        }
    }
}
