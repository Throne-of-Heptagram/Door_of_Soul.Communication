using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Scene
{
    public static class SceneOperationRequestApi
    {
        public static void SendOperationRequest(VirtualScene sender, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            string sceneServerName = null;
            if (sender.WorldId != 0 && CommunicationService.Instance.FindSceneServerName(sender.SceneId, out sceneServerName))
                return;
            DeviceOperationRequestApi.SceneOperationRequest(sceneServerName, sender.WorldId, sender.SceneId, operationCode, parameters);
        }
    }
}
