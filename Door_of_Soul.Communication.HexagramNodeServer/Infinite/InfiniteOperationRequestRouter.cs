using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Infinite.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    class InfiniteOperationRequestRouter : HexagramOperationRequestRouter<InfiniteEventCode, InfiniteOperationCode>
    {
        private InfiniteOperationRequestRouter() : base("Infinite")
        {

        }
    }
}
