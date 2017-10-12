//using Door_of_Soul.Communication.HexagramNodeServer.Infinite.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    public class InfiniteOperationRequestRouter : HexagramOperationRequestRouter<InfiniteHexagramEntrance, VirtualInfinite, InfiniteOperationCode>
    {
        public InfiniteOperationRequestRouter() : base("HexagramNodeServerInfinite")
        {

        }
    }
}
