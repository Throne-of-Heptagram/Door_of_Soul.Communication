using Door_of_Soul.Communication.ObserverServer.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.Scene
{
    public static class SceneOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SceneOperationResponse(terminal, sceneId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
