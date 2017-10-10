using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class DestinyForwardOperationRouter : HexagramForwardOperationRouter<DestinyForwardOperationCode>
    {
        public DestinyForwardOperationRouter() : base("Destiny")
        {
        }
    }
}
