using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.History.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramNodeServer.History
{
    public class HistoryOperationRequestRouter : HexagramOperationRequestRouter<HistoryEventCode, HistoryOperationCode>
    {
        public HistoryOperationRequestRouter() : base("History")
        {

        }
    }
}
