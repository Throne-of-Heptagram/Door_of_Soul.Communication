using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.TrinityServer.EndPoint;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Soul
{
    public static class SoulOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, VirtualSoul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceSoulOperationRequest(deviceId, sender.SoulId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(VirtualSoul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SoulOperationRequest(sender.SoulId, operationCode, parameters);
        }
    }
}
