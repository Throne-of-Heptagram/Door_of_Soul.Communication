using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral.OperationRouter
{
    public class ShadowForwardOperationRouter : HexagramForwardOperationRouter<ShadowForwardOperationCode>
    {
        public ShadowForwardOperationRouter() : base("Shadow")
        {
        }
    }
}
