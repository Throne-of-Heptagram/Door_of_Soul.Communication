using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class LoveForwardOperationRouter : HexagramForwardOperationRouter<LoveForwardOperationCode>
    {
        public LoveForwardOperationRouter() : base("Love")
        {
        }
    }
}
