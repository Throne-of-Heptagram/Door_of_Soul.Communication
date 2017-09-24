using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.ObserverServer;

namespace Door_of_Soul.Communication.ObserverServer.World
{
    class WorldOperationResponseRouter : SubjectOperationResponseRouter<VirtualWorld, WorldOperationCode>
    {
        public static WorldOperationResponseRouter Instance { get; private set; } = new WorldOperationResponseRouter();

        private WorldOperationResponseRouter() : base("ObserverServerWorld")
        {
        }
    }
}
