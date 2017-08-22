using Door_of_Soul.Communication.Protocol.Internal.World;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.World
{
    class WorldEventRouter : EventRouter<Core.World, WorldEventCode>
    {
        public static WorldEventRouter Instance { get; private set; } = new WorldEventRouter();

        private WorldEventRouter()
        {
        }
    }
}
