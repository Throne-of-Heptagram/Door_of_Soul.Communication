using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    class SpaceOperationRequestRouter : HexagramOperationRequestRouter<SpaceEventCode, SpaceOperationCode>
    {
        private SpaceOperationRequestRouter() : base("Space")
        {

        }
    }
}
