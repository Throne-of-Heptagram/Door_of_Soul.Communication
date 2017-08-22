using Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene
{
    public static class SceneOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SceneOperationRequest(deviceId, sceneId, operationCode, parameters);
        }
    }
}
