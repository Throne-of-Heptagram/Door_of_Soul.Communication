using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Shadow
{
    class ShadowEventRouter : BasicEventRouter<ShadowEventCode>
    {
        public static ShadowEventRouter Instance { get; private set; } = new ShadowEventRouter();

        private ShadowEventRouter() : base("Shadow")
        {

        }
    }
}
