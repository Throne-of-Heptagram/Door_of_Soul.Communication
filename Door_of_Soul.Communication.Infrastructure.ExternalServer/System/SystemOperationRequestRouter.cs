using Door_of_Soul.Communication.Protocol.External.System;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.System
{
    class SystemOperationRequestRouter : OperationRequestRouter<Core.Device, Core.System, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter()
        {

        }
    }
}
