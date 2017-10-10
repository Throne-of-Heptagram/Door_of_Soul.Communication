using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class HistoryForwardOperationRouter : HexagramForwardOperationRouter<HistoryForwardOperationCode>
    {
        public HistoryForwardOperationRouter() : base("History")
        {
        }
    }
}
