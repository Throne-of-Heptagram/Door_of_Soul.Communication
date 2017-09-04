using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public class SpaceOperationRequestRouter : HexagramOperationRequestRouter<SpaceEventCode, SpaceOperationCode>
    {
        public SpaceOperationRequestRouter() : base("Space")
        {

        }
    }
}
