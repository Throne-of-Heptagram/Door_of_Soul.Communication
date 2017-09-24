using Door_of_Soul.Communication.LoginServer.System.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.LoginServer;

namespace Door_of_Soul.Communication.LoginServer.System
{
    class SystemOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter() : base("LoginServerSystem")
        {
            OperationTable.Add(SystemOperationCode.Register, new RegisterRequestHandler());
            OperationTable.Add(SystemOperationCode.Login, new LoginRequestHandler());
        }
    }
}
