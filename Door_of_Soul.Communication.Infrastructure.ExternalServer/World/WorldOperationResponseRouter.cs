using Door_of_Soul.Communication.Protocol.Internal.World;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.World
{
    class WorldOperationResponseRouter : OperationResponseRouter<Core.Internal.EndPoint, Core.World, WorldOperationCode>
    {
        public static WorldOperationResponseRouter Instance { get; private set; } = new WorldOperationResponseRouter();

        private WorldOperationResponseRouter()
        {
        }
    }
}
