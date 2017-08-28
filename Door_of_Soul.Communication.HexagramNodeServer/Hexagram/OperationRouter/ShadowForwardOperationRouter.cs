using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class ShadowForwardOperationRouter : ForwardOperationRouter<ShadowForwardOperationCode>
    {
        public static ShadowForwardOperationRouter Instance { get; private set; } = new ShadowForwardOperationRouter();

        public ShadowForwardOperationRouter() : base("Shadow")
        {
        }
    }
}
