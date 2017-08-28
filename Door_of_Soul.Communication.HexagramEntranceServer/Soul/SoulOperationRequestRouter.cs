using Door_of_Soul.Communication.Protocol.Internal.Soul;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Soul
{
    class SoulOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, int, Core.Soul, SoulOperationCode>
    {
        public static SoulOperationRequestRouter Instance { get; private set; } = new SoulOperationRequestRouter();

        private SoulOperationRequestRouter()
        {

        }
    }
}
