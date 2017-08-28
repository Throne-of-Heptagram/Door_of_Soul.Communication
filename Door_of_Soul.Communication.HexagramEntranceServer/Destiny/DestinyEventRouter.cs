using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Destiny
{
    class DestinyEventRouter : EventRouter<DestinyEventCode>
    {
        public static DestinyEventRouter Instance { get; private set; } = new DestinyEventRouter();

        private DestinyEventRouter() : base("Destiny")
        {

        }
    }
}
