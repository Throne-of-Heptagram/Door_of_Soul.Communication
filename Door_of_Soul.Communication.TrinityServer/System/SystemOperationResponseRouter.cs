using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.System
{
    class SystemOperationResponseRouter : SubjectOperationResponseRouter<VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationResponseRouter Instance { get; private set; } = new SystemOperationResponseRouter();

        private SystemOperationResponseRouter() : base("TrinityServerSystem")
        {

        }
    }
}
