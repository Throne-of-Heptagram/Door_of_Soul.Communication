using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.Soul
{
    class SoulOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, VirtualSoul, SoulOperationCode>
    {
        public static SoulOperationRequestRouter Instance { get; private set; } = new SoulOperationRequestRouter();

        private SoulOperationRequestRouter() : base("TrinityServerSoul")
        {

        }
    }
}
