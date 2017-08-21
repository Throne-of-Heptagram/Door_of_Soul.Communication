using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Avatar
{
    public static class AvatarOperationRequestApi
    {
        public static void SendOperationRequest(Core.Avatar sender, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.AvatarOperationRequest(sender, operationCode, parameters);
        }
    }
}
