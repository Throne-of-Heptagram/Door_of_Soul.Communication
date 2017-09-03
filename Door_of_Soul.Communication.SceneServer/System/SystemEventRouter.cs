using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.SceneServer;

namespace Door_of_Soul.Communication.SceneServer.System
{
    class SystemEventRouter : EventRouter<VirtualSystem, SystemEventCode>
    {
        public static SystemEventRouter Instance { get; private set; } = new SystemEventRouter();

        private SystemEventRouter()
        {
        }
    }
}
