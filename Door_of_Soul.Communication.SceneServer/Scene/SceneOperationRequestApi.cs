using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.SceneServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.Scene
{
    public static class SceneOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceSceneOperationRequest(deviceId, sceneId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.EndPointSceneOperationRequest(sceneId, operationCode, parameters);
        }
    }
}
