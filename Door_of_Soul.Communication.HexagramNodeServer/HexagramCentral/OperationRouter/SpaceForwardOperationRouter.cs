using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class SpaceForwardOperationRouter : HexagramForwardOperationRouter<SpaceForwardOperationCode>
    {
        public SpaceForwardOperationRouter() : base("Space")
        {
        }
    }
}
