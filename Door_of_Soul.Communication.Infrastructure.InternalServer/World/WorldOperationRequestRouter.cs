using Door_of_Soul.Communication.Protocol.Internal.World;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.World
{
    class WorldOperationRequestRouter : OperationRequestRouter<Core.Internal.EndPoint, int, Core.World, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter()
        {

        }
    }
}
