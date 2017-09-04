using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Destiny.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramNodeServer.Destiny
{
    public class DestinyOperationRequestRouter : HexagramOperationRequestRouter<DestinyEventCode, DestinyOperationCode>
    {
        public DestinyOperationRequestRouter() : base("Destiny")
        {

        }
    }
}
