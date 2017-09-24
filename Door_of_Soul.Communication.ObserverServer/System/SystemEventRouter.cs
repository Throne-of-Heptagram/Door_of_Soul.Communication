using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.ObserverServer;

namespace Door_of_Soul.Communication.ObserverServer.System
{
    class SystemEventRouter : SubjectEventRouter<VirtualSystem, SystemEventCode>
    {
        public static SystemEventRouter Instance { get; private set; } = new SystemEventRouter();

        private SystemEventRouter() : base("ObserverServerSystem")
        {
        }
    }
}
