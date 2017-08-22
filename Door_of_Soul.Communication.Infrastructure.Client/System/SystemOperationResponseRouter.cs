using Door_of_Soul.Communication.Protocol.External.System;

namespace Door_of_Soul.Communication.Infrastructure.Client.System
{
    class SystemOperationResponseRouter : OperationResponseRouter<Core.Device, Core.System, SystemOperationCode>
    {
        public static SystemOperationResponseRouter Instance { get; private set; } = new SystemOperationResponseRouter();

        private SystemOperationResponseRouter()
        {
        }
    }
}
