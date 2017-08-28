using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class DestinyForwardOperationRouter : ForwardOperationRouter<DestinyForwardOperationCode>
    {
        public static DestinyForwardOperationRouter Instance { get; private set; } = new DestinyForwardOperationRouter();

        public DestinyForwardOperationRouter() : base("Destiny")
        {
        }
    }
}
