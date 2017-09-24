using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.ObserverServer;

namespace Door_of_Soul.Communication.ObserverServer.System
{
    class SystemOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter() : base("ObserverServerSystem")
        {

        }
    }
}
