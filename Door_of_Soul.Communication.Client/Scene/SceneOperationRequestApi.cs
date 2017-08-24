using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Scene
{
    public static class SceneOperationRequestApi
    {
        public static void SendOperationRequest(Core.Scene sender, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (sender.BelongingWorld == null)
                return;
            DeviceOperationRequestApi.SceneOperationRequest(sender.SceneServerName, sender.SceneId, operationCode, parameters);
        }
    }
}
