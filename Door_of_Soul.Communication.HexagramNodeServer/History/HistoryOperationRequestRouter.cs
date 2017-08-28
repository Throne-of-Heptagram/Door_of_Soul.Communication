using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.History.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramNodeServer.History
{
    class HistoryOperationRequestRouter : HexagramOperationRequestRouter<HistoryOperationCode>
    {
        private HistoryOperationRequestRouter() : base("History")
        {

        }
    }
}
