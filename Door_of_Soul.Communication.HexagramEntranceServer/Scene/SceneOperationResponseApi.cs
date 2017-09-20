using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Scene
{
    public static class SceneOperationResponseApi
    {
        public static void SendDeviceOperationResponse(TerminalEndPoint terminal, int deviceId, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.DeviceSceneOperationResponse(terminal, deviceId, sceneId, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void SendEndPointOperationResponse(TerminalEndPoint terminal, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.EndPointSceneOperationResponse(terminal, sceneId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
