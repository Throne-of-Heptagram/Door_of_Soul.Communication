using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.HexagramEntranceServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Avatar
{
    public static class AvatarEventApi
    {
        public static void SendEvent(TerminalEndPoint terminal, VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.AvatarEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.BroadcastAvatarEvent(target, eventCode, parameters);
        }
    }
}
