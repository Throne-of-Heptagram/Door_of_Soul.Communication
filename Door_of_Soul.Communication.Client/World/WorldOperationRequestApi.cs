using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.World
{
    public static class WorldOperationRequestApi
    {
        public static void SendOperationRequest(VirtualWorld sender, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.WorldOperationRequest(sender.WorldId, operationCode, parameters);
        }
    }
}
