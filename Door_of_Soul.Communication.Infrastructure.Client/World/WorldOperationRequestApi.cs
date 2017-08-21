using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.World
{
    public static class WorldOperationRequestApi
    {
        public static void SendOperationRequest(Core.World sender, string authenticationToken, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.WorldOperationRequest(sender, authenticationToken, operationCode, parameters);
        }
    }
}
