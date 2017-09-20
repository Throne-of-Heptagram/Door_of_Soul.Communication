using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.ProxyServer.EndPoint;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Avatar
{
    public static class AvatarOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, VirtualAvatar sender, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceAvatarOperationRequest(deviceId, sender.AvatarId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(VirtualAvatar sender, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.EndPointAvatarOperationRequest(sender.AvatarId, operationCode, parameters);
        }
    }
}
