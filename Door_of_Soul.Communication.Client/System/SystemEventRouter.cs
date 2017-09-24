using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.System
{
    class SystemEventRouter : SubjectEventRouter<VirtualSystem, SystemEventCode>
    {
        public static SystemEventRouter Instance { get; private set; } = new SystemEventRouter();

        private SystemEventRouter() : base("ClientSystem")
        {

        }
    }
}
