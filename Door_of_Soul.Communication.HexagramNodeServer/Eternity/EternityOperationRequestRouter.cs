//using Door_of_Soul.Communication.HexagramNodeServer.Eternity.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Eternity
{
    public class EternityOperationRequestRouter : HexagramOperationRequestRouter<EternityHexagramEntrance, VirtualEternity, EternityOperationCode>
    {
        public EternityOperationRequestRouter() : base("HexagramNodeServerElement")
        {

        }
    }
}
