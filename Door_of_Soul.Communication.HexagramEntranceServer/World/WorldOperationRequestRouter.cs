using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.World
{
    class WorldOperationRequestRouter : L2SubjectOperationRequestRouter<TerminalEndPoint, int, VirtualWorld, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter() : base("HexagramEntranceServerWorld")
        {

        }
    }
}
