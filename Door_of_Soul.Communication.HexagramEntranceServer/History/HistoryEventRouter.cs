using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramEntranceServer.History
{
    class HistoryEventRouter : BasicEventRouter<HistoryEventCode>
    {
        public static HistoryEventRouter Instance { get; private set; } = new HistoryEventRouter();

        private HistoryEventRouter() : base("History")
        {

        }
    }
}
