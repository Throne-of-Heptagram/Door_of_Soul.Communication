using Door_of_Soul.Communication.Protocol.Internal.World;

namespace Door_of_Soul.Communication.HexagramEntranceServer.World
{
    class WorldOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, int, Core.World, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter()
        {

        }
    }
}
