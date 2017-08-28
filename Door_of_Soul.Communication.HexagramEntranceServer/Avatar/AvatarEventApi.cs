using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Avatar
{
    public static class AvatarEventApi
    {
        public static void SendEvent(Core.Avatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.AvatarEvent(target, eventCode, parameters);
        }
    }
}
