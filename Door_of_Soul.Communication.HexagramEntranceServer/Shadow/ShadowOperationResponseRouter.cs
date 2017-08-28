using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Shadow
{
    class ShadowOperationResponseRouter : OperationResponseRouter<ShadowOperationCode>
    {
        public static ShadowOperationResponseRouter Instance { get; private set; } = new ShadowOperationResponseRouter();

        private ShadowOperationResponseRouter() : base("Shadow")
        {

        }
    }
}
