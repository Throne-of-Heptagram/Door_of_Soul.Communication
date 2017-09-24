using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Communication.ObserverServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.World
{
    public static class WorldOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceWorldOperationRequest(deviceId, worldId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.WorldOperationRequest(worldId, operationCode, parameters);
        }
    }
}
