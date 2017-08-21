using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene
{
    public static class SceneEventApi
    {
        public static void SendEvent(Core.Scene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SceneEvent(target, eventCode, parameters);
        }
    }
}
