using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Soul
{
    class SoulOperationRequestRouter : L2SubjectOperationRequestRouter<TerminalEndPoint, int, VirtualSoul, SoulOperationCode>
    {
        public static SoulOperationRequestRouter Instance { get; private set; } = new SoulOperationRequestRouter();

        private SoulOperationRequestRouter() : base("HexagramEntranceServerSoul")
        {

        }
    }
}
