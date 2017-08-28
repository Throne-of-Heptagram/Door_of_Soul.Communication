using Door_of_Soul.Communication.Protocol.Hexagram.Life;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class LifeForwardOperationRouter : ForwardOperationRouter<LifeForwardOperationCode>
    {
        public static LifeForwardOperationRouter Instance { get; private set; } = new LifeForwardOperationRouter();

        public LifeForwardOperationRouter() : base("Life")
        {
        }
    }
}
