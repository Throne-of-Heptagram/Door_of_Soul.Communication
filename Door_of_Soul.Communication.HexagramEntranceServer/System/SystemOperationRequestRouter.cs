using Door_of_Soul.Communication.Protocol.Internal.System;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System
{
    class SystemOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, int, Core.System, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter()
        {

        }
    }
}
