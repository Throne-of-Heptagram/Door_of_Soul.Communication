using Door_of_Soul.Communication.Protocol.External.System;

namespace Door_of_Soul.Communication.Infrastructure.Client.System
{
    class SystemEventRouter : EventRouter<Core.System, SystemEventCode>
    {
        public static SystemEventRouter Instance { get; private set; } = new SystemEventRouter();

        private SystemEventRouter()
        {
        }
    }
}
