using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    class SoulEventRouter : EventRouter<VirtualSoul, SoulEventCode>
    {
        public static SoulEventRouter Instance { get; private set; } = new SoulEventRouter();

        private SoulEventRouter()
        {
        }
    }
}
