using Door_of_Soul.Communication.Protocol.Internal.Soul;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul
{
    class SoulEventRouter : EventRouter<Core.Soul, SoulEventCode>
    {
        public static SoulEventRouter Instance { get; private set; } = new SoulEventRouter();

        private SoulEventRouter()
        {
        }
    }
}
