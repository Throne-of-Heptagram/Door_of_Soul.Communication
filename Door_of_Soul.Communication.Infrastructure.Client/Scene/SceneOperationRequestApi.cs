using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Scene
{
    public static class SceneOperationRequestApi
    {
        public static void SendOperationRequest(Core.Scene sender, SceneOperationCode operationCode, Dictionary<byte, object> parameters, bool isToPhysicsServer)
        {
            if (sender.BelongingWorld == null)
                return;
            DeviceOperationRequestApi.SceneOperationRequest(sender.SceneId, operationCode, parameters, isToPhysicsServer);
        }
    }
}
