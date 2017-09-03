using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.ProxyServer.EndPoint;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    public static class SoulOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, VirtualSoul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SoulOperationRequest(deviceId, sender.SoulId, operationCode, parameters);
        }
    }
}
