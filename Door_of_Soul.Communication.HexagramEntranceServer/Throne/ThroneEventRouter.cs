using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    class ThroneEventRouter : BasicEventRouter<ThroneEventCode>
    {
        public static ThroneEventRouter Instance { get; private set; } = new ThroneEventRouter();

        private ThroneEventRouter() : base("HexagramEntranceServerThrone")
        {

        }
    }
}
