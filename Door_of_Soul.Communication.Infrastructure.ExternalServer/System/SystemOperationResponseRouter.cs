using Door_of_Soul.Communication.Protocol.Internal.System;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.System
{
    class SystemOperationResponseRouter : OperationResponseRouter<Core.InternalServer.EndPoint, Core.System, SystemOperationCode>
    {
        public static SystemOperationResponseRouter Instance { get; private set; } = new SystemOperationResponseRouter();

        private SystemOperationResponseRouter()
        {
        }
    }
}
