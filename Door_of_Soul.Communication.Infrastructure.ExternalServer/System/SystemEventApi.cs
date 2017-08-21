using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.System
{
    public static class SystemEventApi
    {
        public static void SendEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SystemEvent(eventCode, parameters);
        }
    }
}
