using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class ThroneForwardOperationRouter : HexagramForwardOperationRouter<ThroneForwardOperationCode>
    {
        public ThroneForwardOperationRouter() : base("Throne")
        {
        }
    }
}
