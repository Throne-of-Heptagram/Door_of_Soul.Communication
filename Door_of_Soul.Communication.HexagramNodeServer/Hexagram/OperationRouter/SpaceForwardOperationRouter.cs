using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class SpaceForwardOperationRouter : ForwardOperationRouter<SpaceForwardOperationCode>
    {
        public static SpaceForwardOperationRouter Instance { get; private set; } = new SpaceForwardOperationRouter();

        public SpaceForwardOperationRouter() : base("Space")
        {
        }
    }
}
