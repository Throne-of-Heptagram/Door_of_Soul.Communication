using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.Soul.EventParameter;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.ProxyServer.Soul
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

        public static void LoadProxyAvatar(TerminalDevice terminal, VirtualSoul target, VirtualAvatar avatar)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)LoadProxyAvatarParameterCode.AvatarId, avatar.AvatarId },
                { (byte)LoadProxyAvatarParameterCode.EntityId, avatar.EntityId },
                { (byte)LoadProxyAvatarParameterCode.AvatarName, avatar.AvatarName },
                { (byte)LoadProxyAvatarParameterCode.SoulIds, avatar.SoulIds.ToArray() }
            };
            SendEvent(terminal, target, SoulEventCode.LoadProxyAvatar, eventParameters);
        }
    }
}
