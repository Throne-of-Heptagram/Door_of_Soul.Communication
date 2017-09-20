using Door_of_Soul.Communication.SceneServer.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.Scene
{
    public static class SceneEventApi
    {
        public static void SendEvent(TerminalDevice terminal, TerminalScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SceneEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(TerminalScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.BroadcastSceneEvent(target, eventCode, parameters);
        }
    }
}
