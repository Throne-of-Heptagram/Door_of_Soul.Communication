using Door_of_Soul.Communication.Protocol.External.World;

namespace Door_of_Soul.Communication.Infrastructure.Client.World
{
    class WorldOperationResponseRouter : OperationResponseRouter<Core.World, WorldOperationCode>
    {
        public static WorldOperationResponseRouter Instance { get; private set; } = new WorldOperationResponseRouter();

        private WorldOperationResponseRouter()
        {
        }
    }
}
