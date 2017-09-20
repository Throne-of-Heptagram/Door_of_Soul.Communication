using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Communication.SceneServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.World
{
    public static class WorldOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceWorldOperationRequest(deviceId, worldId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.EndPointWorldOperationRequest(worldId, operationCode, parameters);
        }
    }
}
