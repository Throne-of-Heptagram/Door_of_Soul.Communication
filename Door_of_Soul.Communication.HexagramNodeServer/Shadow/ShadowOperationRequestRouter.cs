using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
//using Door_of_Soul.Communication.HexagramNodeServer.Shadow.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Shadow
{
    public class ShadowOperationRequestRouter : HexagramOperationRequestRouter<ShadowEventCode, ShadowOperationCode, VirtualShadow>
    {
        public ShadowOperationRequestRouter()
        {

        }
    }
}
