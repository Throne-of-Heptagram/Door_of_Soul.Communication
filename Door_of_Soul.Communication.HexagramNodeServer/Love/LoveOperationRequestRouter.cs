using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Love.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    class LoveOperationRequestRouter : HexagramOperationRequestRouter<LoveEventCode, LoveOperationCode>
    {
        private LoveOperationRequestRouter() : base("Love")
        {

        }
    }
}
