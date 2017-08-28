using Door_of_Soul.Communication.SceneServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.Scene
{
    public static class SceneOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, int worldId, int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SceneOperationRequest(deviceId, worldId, sceneId, operationCode, parameters);
        }
    }
}
