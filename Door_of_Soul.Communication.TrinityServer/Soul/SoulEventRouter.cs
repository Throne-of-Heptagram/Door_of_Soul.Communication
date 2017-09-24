using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.Soul
{
    class SoulEventRouter : SubjectEventRouter<VirtualSoul, SoulEventCode>
    {
        public static SoulEventRouter Instance { get; private set; } = new SoulEventRouter();

        private SoulEventRouter() : base("TrinityServerSoul")
        {
        }
    }
}
