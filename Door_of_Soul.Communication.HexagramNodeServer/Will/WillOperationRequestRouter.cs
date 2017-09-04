using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Will.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public class WillOperationRequestRouter : HexagramOperationRequestRouter<WillEventCode, WillOperationCode>
    {
        public WillOperationRequestRouter() : base("Will")
        {

        }
    }
}
