using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.System
{
    class SystemOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter() : base("TrinityServerSystem")
        {

        }
    }
}
