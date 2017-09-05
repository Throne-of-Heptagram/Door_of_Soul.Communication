using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    public class WillForwardOperationRouter : HexagramForwardOperationRouter<WillForwardOperationCode>
    {
        public WillForwardOperationRouter() : base("Will")
        {
        }
    }
}
