using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    class ThroneEventRouter : EventRouter<ThroneEventCode>
    {
        public static ThroneEventRouter Instance { get; private set; } = new ThroneEventRouter();

        private ThroneEventRouter() : base("Throne")
        {

        }
    }
}
