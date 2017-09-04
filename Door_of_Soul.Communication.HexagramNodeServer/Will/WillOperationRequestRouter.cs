using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Will.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    class WillOperationRequestRouter : HexagramOperationRequestRouter<WillEventCode, WillOperationCode>
    {
        private WillOperationRequestRouter() : base("Will")
        {

        }
    }
}
