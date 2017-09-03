using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.SceneServer;

namespace Door_of_Soul.Communication.SceneServer.System
{
    class SystemOperationResponseRouter : OperationResponseRouter<VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationResponseRouter Instance { get; private set; } = new SystemOperationResponseRouter();

        private SystemOperationResponseRouter()
        {
        }
    }
}
