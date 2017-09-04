using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Shadow.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer.Shadow
{
    class ShadowOperationRequestRouter : HexagramOperationRequestRouter<ShadowEventCode, ShadowOperationCode>
    {
        private ShadowOperationRequestRouter() : base("Shadow")
        {

        }
    }
}
