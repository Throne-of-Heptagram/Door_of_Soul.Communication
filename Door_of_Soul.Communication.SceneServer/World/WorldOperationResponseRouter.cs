using Door_of_Soul.Communication.Protocol.Internal.World;

namespace Door_of_Soul.Communication.SceneServer.World
{
    class WorldOperationResponseRouter : OperationResponseRouter<Core.World, WorldOperationCode>
    {
        public static WorldOperationResponseRouter Instance { get; private set; } = new WorldOperationResponseRouter();

        private WorldOperationResponseRouter()
        {
        }
    }
}
