using Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.World
{
    public static class WorldOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.WorldOperationRequest(deviceId, worldId, operationCode, parameters);
        }
    }
}
