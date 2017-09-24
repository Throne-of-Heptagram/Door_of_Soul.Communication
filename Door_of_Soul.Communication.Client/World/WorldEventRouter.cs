using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.World
{
    class WorldEventRouter : SubjectEventRouter<VirtualWorld, WorldEventCode>
    {
        public static WorldEventRouter Instance { get; private set; } = new WorldEventRouter();

        private WorldEventRouter() : base("ClientWorld")
        {
        }
    }
}
