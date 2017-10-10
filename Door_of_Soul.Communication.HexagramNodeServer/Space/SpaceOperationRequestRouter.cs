using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public class SpaceOperationRequestRouter : HexagramOperationRequestRouter<SpaceEventCode, SpaceOperationCode, VirtualSpace>
    {
        public SpaceOperationRequestRouter() : base("HexagramNodeServerSpace")
        {

        }
    }
}
