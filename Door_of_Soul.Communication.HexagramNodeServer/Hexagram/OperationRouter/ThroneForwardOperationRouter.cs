using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class ThroneForwardOperationRouter : ForwardOperationRouter<ThroneForwardOperationCode>
    {
        public static ThroneForwardOperationRouter Instance { get; private set; } = new ThroneForwardOperationRouter();

        public ThroneForwardOperationRouter() : base("Throne")
        {
        }
    }
}
