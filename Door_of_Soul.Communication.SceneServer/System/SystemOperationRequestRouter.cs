using Door_of_Soul.Communication.Protocol.External.System;

namespace Door_of_Soul.Communication.SceneServer.System
{
    class SystemOperationRequestRouter : OperationRequestRouter<TerminalDevice, Core.System, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter()
        {

        }
    }
}
