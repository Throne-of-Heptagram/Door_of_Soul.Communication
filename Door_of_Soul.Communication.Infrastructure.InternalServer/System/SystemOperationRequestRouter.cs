using Door_of_Soul.Communication.Protocol.Internal.System;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.System
{
    class SystemOperationRequestRouter : OperationRequestRouter<Core.Internal.EndPoint, int, Core.System, SystemOperationCode>
    {
        public static SystemOperationRequestRouter Instance { get; private set; } = new SystemOperationRequestRouter();

        private SystemOperationRequestRouter()
        {

        }
    }
}
