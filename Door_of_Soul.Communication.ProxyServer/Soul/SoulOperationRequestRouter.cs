using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    class SoulOperationRequestRouter : OperationRequestRouter<TerminalDevice, VirtualSoul, SoulOperationCode>
    {
        public static SoulOperationRequestRouter Instance { get; private set; } = new SoulOperationRequestRouter();

        private SoulOperationRequestRouter()
        {

        }
    }
}
