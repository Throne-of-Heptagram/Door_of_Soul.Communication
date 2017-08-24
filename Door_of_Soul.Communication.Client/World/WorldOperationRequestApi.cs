using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.World
{
    public static class WorldOperationRequestApi
    {
        public static void SendOperationRequest(string sceneServerName, Core.World sender, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.WorldOperationRequest(sceneServerName, sender.WorldId, operationCode, parameters);
        }
    }
}
