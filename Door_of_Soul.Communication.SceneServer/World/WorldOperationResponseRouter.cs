using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.SceneServer;

namespace Door_of_Soul.Communication.SceneServer.World
{
    class WorldOperationResponseRouter : OperationResponseRouter<VirtualWorld, WorldOperationCode>
    {
        public static WorldOperationResponseRouter Instance { get; private set; } = new WorldOperationResponseRouter();

        private WorldOperationResponseRouter()
        {
        }
    }
}
