using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.TrinityServer.Device;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Avatar
{
    public static class AvatarEventApi
    {
        public static void SendEvent(TerminalDevice terminal, VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.AvatarEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.BroadcastAvatarEvent(target, eventCode, parameters);
        }
    }
}
