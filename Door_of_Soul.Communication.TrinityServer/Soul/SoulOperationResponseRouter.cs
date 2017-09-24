using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.Soul
{
    class SoulOperationResponseRouter : SubjectOperationResponseRouter<VirtualSoul, SoulOperationCode>
    {
        public static SoulOperationResponseRouter Instance { get; private set; } = new SoulOperationResponseRouter();

        private SoulOperationResponseRouter() : base("TrinityServerSoul")
        {

        }
    }
}
