using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public class SpaceOperationRequestRouter : HexagramOperationRequestRouter<SpaceHexagramEntrance, VirtualSpace, SpaceOperationCode>
    {
        public SpaceOperationRequestRouter() : base("HexagramNodeServerSpace")
        {

        }
    }
}
