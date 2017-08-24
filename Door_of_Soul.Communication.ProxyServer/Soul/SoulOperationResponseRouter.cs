using Door_of_Soul.Communication.Protocol.Internal.Soul;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    class SoulOperationResponseRouter : OperationResponseRouter<Core.Internal.EndPoint, Core.Soul, SoulOperationCode>
    {
        public static SoulOperationResponseRouter Instance { get; private set; } = new SoulOperationResponseRouter();

        private SoulOperationResponseRouter()
        {
        }
    }
}
