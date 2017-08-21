using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Avatar
{
    public static class AvatarEventApi
    {
        public static void SendEvent(Core.Avatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.AvatarEvent(target, eventCode, parameters);
        }
    }
}
