using Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Avatar
{
    public static class AvatarOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, Core.Avatar sender, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.AvatarOperationRequest(deviceId, sender.AvatarId, operationCode, parameters);
        }
    }
}
