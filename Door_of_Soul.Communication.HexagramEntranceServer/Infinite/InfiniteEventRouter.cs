using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Infinite
{
    class InfiniteEventRouter : EventRouter<InfiniteEventCode>
    {
        public static InfiniteEventRouter Instance { get; private set; } = new InfiniteEventRouter();

        private InfiniteEventRouter() : base("Infinite")
        {

        }
    }
}
