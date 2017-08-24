using Door_of_Soul.Communication.Protocol.External.World;

namespace Door_of_Soul.Communication.SceneServer.World
{
    class WorldOperationRequestRouter : OperationRequestRouter<TerminalDevice, Core.World, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter()
        {

        }
    }
}
