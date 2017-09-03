using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.SceneServer;

namespace Door_of_Soul.Communication.SceneServer.System
{
    class SystemOperationRequestRouter : OperationRequestRouter<TerminalDevice, VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter()
        {

        }
    }
}
