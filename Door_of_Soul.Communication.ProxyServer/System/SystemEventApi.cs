using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Communication.Protocol.External.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.System
{
    public static class SystemEventApi
    {
        public static void SendEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SystemEvent(eventCode, parameters);
        }
    }
}
