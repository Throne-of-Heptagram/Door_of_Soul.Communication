using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.World
{
    class WorldOperationResponseRouter : OperationResponseRouter<VirtualWorld, WorldOperationCode>
    {
        public static WorldOperationResponseRouter Instance { get; private set; } = new WorldOperationResponseRouter();

        private WorldOperationResponseRouter()
        {
        }
    }
}
