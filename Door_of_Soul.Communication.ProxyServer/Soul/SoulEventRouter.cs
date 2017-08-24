using Door_of_Soul.Communication.Protocol.Internal.Soul;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    class SoulEventRouter : EventRouter<Core.Soul, SoulEventCode>
    {
        public static SoulEventRouter Instance { get; private set; } = new SoulEventRouter();

        private SoulEventRouter()
        {
        }
    }
}
