using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.Avatar
{
    public static class AvatarEventApi
    {
        public static void SendEvent(Core.Avatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.AvatarEvent(target, eventCode, parameters);
        }
    }
}
