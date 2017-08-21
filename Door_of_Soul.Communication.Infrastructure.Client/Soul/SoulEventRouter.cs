using Door_of_Soul.Communication.Protocol.External.Soul;

namespace Door_of_Soul.Communication.Infrastructure.Client.Soul
{
    class SoulEventRouter : EventRouter<Core.Soul, SoulEventCode>
    {
        public static SoulEventRouter Instance { get; private set; } = new SoulEventRouter();

        private SoulEventRouter()
        {
        }
    }
}
