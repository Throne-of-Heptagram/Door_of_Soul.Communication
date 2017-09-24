using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.TrinityServer.Device;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Soul
{
    public static class SoulEventApi
    {
        public static void SendEvent(TerminalDevice terminal, VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SoulEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.BroadcastSoulEvent(target, eventCode, parameters);
        }
    }
}
