using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
//using Door_of_Soul.Communication.HexagramNodeServer.Eternity.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Eternity
{
    public class EternityOperationRequestRouter : HexagramOperationRequestRouter<EternityEventCode, EternityOperationCode, VirtualEternity>
    {
        public EternityOperationRequestRouter() : base("HexagramNodeServerElement")
        {

        }
    }
}
