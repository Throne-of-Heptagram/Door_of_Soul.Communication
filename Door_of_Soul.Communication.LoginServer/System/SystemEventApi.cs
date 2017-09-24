using Door_of_Soul.Communication.LoginServer.Device;
using Door_of_Soul.Communication.Protocol.External.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System
{
    public static class SystemEventApi
    {
        public static void SendEvent(TerminalDevice terminal, SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SystemEvent(terminal, eventCode, parameters);
        }

        public static void SendBroadcastEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.BroadcastSystemEvent(eventCode, parameters);
        }
    }
}
