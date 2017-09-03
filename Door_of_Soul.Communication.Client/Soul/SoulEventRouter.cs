using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Soul
{
    class SoulEventRouter : EventRouter<VirtualSoul, SoulEventCode>
    {
        public static SoulEventRouter Instance { get; private set; } = new SoulEventRouter();

        private SoulEventRouter()
        {
        }
    }
}
