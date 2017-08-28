using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Eternity
{
    class EternityEventRouter : EventRouter<EternityEventCode>
    {
        public static EternityEventRouter Instance { get; private set; } = new EternityEventRouter();

        private EternityEventRouter() : base("Eternity")
        {

        }
    }
}
