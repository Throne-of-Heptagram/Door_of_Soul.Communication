//using Door_of_Soul.Communication.HexagramNodeServer.Love.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public class LoveOperationRequestRouter : HexagramOperationRequestRouter<LoveHexagramEntrance, VirtualLove, LoveOperationCode>
    {
        public LoveOperationRequestRouter() : base("HexagramNodeServerLove")
        {

        }
    }
}
