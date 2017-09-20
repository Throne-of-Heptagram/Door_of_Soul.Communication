using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.HexagramEntranceServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Scene
{
    public static class SceneEventApi
    {
        public static void SendEvent(TerminalEndPoint terminal, VirtualScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.SceneEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.BroadcastSceneEvent(target, eventCode, parameters);
        }
    }
}
