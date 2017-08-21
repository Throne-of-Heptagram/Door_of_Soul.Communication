using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.Soul;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul
{
    public static class SoulEventApi
    {
        public static void SendEvent(Core.Soul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SoulEvent(target, eventCode, parameters);
        }
    }
}
