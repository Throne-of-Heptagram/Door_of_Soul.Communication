using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.SceneServer;

namespace Door_of_Soul.Communication.SceneServer.World
{
    class WorldEventRouter : EventRouter<VirtualWorld, WorldEventCode>
    {
        public static WorldEventRouter Instance { get; private set; } = new WorldEventRouter();

        private WorldEventRouter()
        {
        }
    }
}
