using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class InfiniteForwardOperationRouter : ForwardOperationRouter<InfiniteForwardOperationCode>
    {
        public static InfiniteForwardOperationRouter Instance { get; private set; } = new InfiniteForwardOperationRouter();

        public InfiniteForwardOperationRouter() : base("Infinite")
        {
        }
    }
}
