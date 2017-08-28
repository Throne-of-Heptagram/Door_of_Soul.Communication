using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class HistoryForwardOperationRouter : ForwardOperationRouter<HistoryForwardOperationCode>
    {
        public static HistoryForwardOperationRouter Instance { get; private set; } = new HistoryForwardOperationRouter();

        public HistoryForwardOperationRouter() : base("History")
        {
        }
    }
}
