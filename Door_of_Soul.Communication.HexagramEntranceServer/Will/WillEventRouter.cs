using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Will
{
    class WillEventRouter : BasicEventRouter<WillEventCode>
    {
        public static WillEventRouter Instance { get; private set; } = new WillEventRouter();

        private WillEventRouter() : base("Will")
        {

        }
    }
}
