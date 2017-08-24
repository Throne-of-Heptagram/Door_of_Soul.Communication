using Door_of_Soul.Communication.Protocol.External.System;

namespace Door_of_Soul.Communication.ProxyServer.System
{
    class SystemOperationRequestRouter : OperationRequestRouter<Core.External.Device, Core.System, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter()
        {

        }
    }
}
