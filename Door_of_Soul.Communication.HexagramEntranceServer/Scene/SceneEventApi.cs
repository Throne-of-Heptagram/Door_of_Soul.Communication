using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.HexagramEntranceServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Scene
{
    public static class SceneEventApi
    {
        public static void SendEvent(VirtualScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.SceneEvent(target, eventCode, parameters);
        }
    }
}
