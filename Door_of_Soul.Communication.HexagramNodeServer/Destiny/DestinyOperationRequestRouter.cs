using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Destiny.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Destiny
{
    public class DestinyOperationRequestRouter : HexagramOperationRequestRouter<DestinyEventCode, DestinyOperationCode, VirtualDestiny>
    {
        public DestinyOperationRequestRouter()
        {

        }
    }
}
