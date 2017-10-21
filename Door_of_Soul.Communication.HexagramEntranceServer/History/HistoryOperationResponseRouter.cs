using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramEntranceServer.History
{
    class HistoryOperationResponseRouter : BasicOperationResponseRouter<HistoryOperationCode>
    {
        public static HistoryOperationResponseRouter Instance { get; private set; } = new HistoryOperationResponseRouter();

        private HistoryOperationResponseRouter() : base("History")
        {

        }
    }
}
