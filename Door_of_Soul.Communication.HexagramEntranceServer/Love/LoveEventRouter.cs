using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Love
{
    class LoveEventRouter : EventRouter<LoveEventCode>
    {
        public static LoveEventRouter Instance { get; private set; } = new LoveEventRouter();

        private LoveEventRouter() : base("Love")
        {

        }
    }
}
