using Door_of_Soul.Communication.Protocol.External.World;

namespace Door_of_Soul.Communication.Client.World
{
    class WorldEventRouter : EventRouter<Core.World, WorldEventCode>
    {
        public static WorldEventRouter Instance { get; private set; } = new WorldEventRouter();

        private WorldEventRouter()
        {
        }
    }
}
