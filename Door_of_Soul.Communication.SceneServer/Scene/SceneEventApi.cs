using Door_of_Soul.Communication.SceneServer.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.Scene
{
    public static class SceneEventApi
    {
        public static void SendEvent(TerminalScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SceneEvent(target, eventCode, parameters);
        }
    }
}
