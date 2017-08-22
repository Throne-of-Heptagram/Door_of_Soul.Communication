using Door_of_Soul.Communication.Protocol.Internal.Soul;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul
{
    class SoulOperationResponseRouter : OperationResponseRouter<Core.InternalServer.EndPoint, Core.Soul, SoulOperationCode>
    {
        public static SoulOperationResponseRouter Instance { get; private set; } = new SoulOperationResponseRouter();

        private SoulOperationResponseRouter()
        {
        }
    }
}
