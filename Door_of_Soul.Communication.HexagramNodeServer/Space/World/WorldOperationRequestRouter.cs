using Door_of_Soul.Communication.Protocol.Internal.World;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space.World
{
    class WorldOperationRequestRouter : OperationRequestRouter<TerminalHexagramEntrance, int, int, Core.World, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter()
        {

        }
    }
}
