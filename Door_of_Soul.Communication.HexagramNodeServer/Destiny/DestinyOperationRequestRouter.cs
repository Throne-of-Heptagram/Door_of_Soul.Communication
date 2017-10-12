//using Door_of_Soul.Communication.HexagramNodeServer.Destiny.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Destiny
{
    public class DestinyOperationRequestRouter : HexagramOperationRequestRouter<DestinyHexagramEntrance, VirtualDestiny, DestinyOperationCode>
    {
        public DestinyOperationRequestRouter() : base("HexagramNodeServerDestiny")
        {

        }
    }
}
