using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Scene
{
    public static class SceneOperationRequestApi
    {
        public static void SendOperationRequest(Core.Scene sender, Core.Avatar observer, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.SceneOperationRequest(sender, observer, operationCode, parameters);
        }
    }
}
