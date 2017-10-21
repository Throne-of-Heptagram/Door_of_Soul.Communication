using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Space
{
    class SpaceEventRouter : BasicEventRouter<SpaceEventCode>
    {
        public static SpaceEventRouter Instance { get; private set; } = new SpaceEventRouter();

        private SpaceEventRouter() : base("Space")
        {

        }
    }
}
