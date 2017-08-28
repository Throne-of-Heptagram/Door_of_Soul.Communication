using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class LoveForwardOperationRouter : ForwardOperationRouter<LoveForwardOperationCode>
    {
        public static LoveForwardOperationRouter Instance { get; private set; } = new LoveForwardOperationRouter();

        public LoveForwardOperationRouter() : base("Love")
        {
        }
    }
}
