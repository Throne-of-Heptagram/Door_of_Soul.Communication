using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.Scene
{
    public static class SceneEventApi
    {
        public static void SendEvent(Core.Scene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.SceneEvent(target, eventCode, parameters);
        }
    }
}
