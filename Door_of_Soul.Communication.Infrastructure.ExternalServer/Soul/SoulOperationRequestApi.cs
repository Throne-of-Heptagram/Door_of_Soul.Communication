using Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul
{
    public static class SoulOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, Core.Soul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SoulOperationRequest(deviceId, sender.SoulId, operationCode, parameters);
        }
    }
}
