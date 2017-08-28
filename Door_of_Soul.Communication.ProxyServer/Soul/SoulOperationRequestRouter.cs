using Door_of_Soul.Communication.Protocol.External.Soul;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    class SoulOperationRequestRouter : OperationRequestRouter<TerminalDevice, Core.Soul, SoulOperationCode>
    {
        public static SoulOperationRequestRouter Instance { get; private set; } = new SoulOperationRequestRouter();

        private SoulOperationRequestRouter()
        {

        }
    }
}
