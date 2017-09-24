using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.ObserverServer;

namespace Door_of_Soul.Communication.ObserverServer.World
{
    class WorldEventRouter : SubjectEventRouter<VirtualWorld, WorldEventCode>
    {
        public static WorldEventRouter Instance { get; private set; } = new WorldEventRouter();

        private WorldEventRouter() : base("ObserverServerWolrd")
        {
        }
    }
}
