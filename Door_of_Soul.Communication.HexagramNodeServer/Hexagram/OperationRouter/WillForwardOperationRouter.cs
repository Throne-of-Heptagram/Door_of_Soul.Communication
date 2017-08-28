using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class WillForwardOperationRouter : ForwardOperationRouter<WillForwardOperationCode>
    {
        public static WillForwardOperationRouter Instance { get; private set; } = new WillForwardOperationRouter();

        public WillForwardOperationRouter() : base("Will")
        {
        }
    }
}
