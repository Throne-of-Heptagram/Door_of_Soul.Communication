using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;

namespace Door_of_Soul.Communication.HexagramNodeServer.Hexagram.OperationRouter
{
    class EternityForwardOperationRouter : ForwardOperationRouter<EternityForwardOperationCode>
    {
        public static EternityForwardOperationRouter Instance { get; private set; } = new EternityForwardOperationRouter();

        public EternityForwardOperationRouter() : base("Eternity")
        {
        }
    }
}
