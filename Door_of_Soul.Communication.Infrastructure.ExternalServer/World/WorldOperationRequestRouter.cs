using Door_of_Soul.Communication.Protocol.External.World;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.World
{
    class WorldOperationRequestRouter : OperationRequestRouter<Core.World, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter()
        {

        }
    }
}
