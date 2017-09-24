using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.ObserverServer;

namespace Door_of_Soul.Communication.ObserverServer.World
{
    class WorldOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, VirtualWorld, WorldOperationCode>
    {
        public static WorldOperationRequestRouter Instance { get; private set; } = new WorldOperationRequestRouter();

        private WorldOperationRequestRouter() : base("ObserverServerWorld")
        {

        }
    }
}
