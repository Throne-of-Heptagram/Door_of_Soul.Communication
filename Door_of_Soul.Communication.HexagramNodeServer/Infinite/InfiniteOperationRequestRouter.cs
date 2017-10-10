using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
//using Door_of_Soul.Communication.HexagramNodeServer.Infinite.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    public class InfiniteOperationRequestRouter : HexagramOperationRequestRouter<InfiniteEventCode, InfiniteOperationCode, VirtualInfinite>
    {
        public InfiniteOperationRequestRouter() : base("HexagramNodeServerInfinite")
        {

        }
    }
}
