using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.TrinityServer;

namespace Door_of_Soul.Communication.TrinityServer.System
{
    class SystemEventRouter : SubjectEventRouter<VirtualSystem, SystemEventCode>
    {
        public static SystemEventRouter Instance { get; private set; } = new SystemEventRouter();

        private SystemEventRouter() : base("TrinityServerSystem")
        {
        }
    }
}
