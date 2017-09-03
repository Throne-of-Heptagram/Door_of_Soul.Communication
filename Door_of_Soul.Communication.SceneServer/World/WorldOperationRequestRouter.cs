using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.SceneServer;

namespace Door_of_Soul.Communication.SceneServer.World
{
    class WorldOperationRequestRouter : OperationRequestRouter<TerminalDevice, VirtualWorld, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter()
        {

        }
    }
}
