using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene
{
    public static class SceneOperationResponseApi
    {
        public static void SendOperationResponse(Core.Device terminal, Core.Scene target, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SceneOperationResponse(terminal, target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
