using Door_of_Soul.Communication.HexagramEntranceServer.System.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System
{
    class SystemOperationRequestRouter : L2SubjectOperationRequestRouter<TerminalEndPoint, int, VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter() : base("HexagramEntranceServerSystem")
        {
            L2OperationTable.Add(SystemOperationCode.DeviceRegister, new DeviceRegisterRequestHandler());
        }
    }
}
