using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class WillForwardOperationRouter : HexagramForwardOperationRouter<WillForwardOperationCode>
    {
        public WillForwardOperationRouter() : base("Will")
        {
        }
    }
}
