using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.Soul.OperationRequestParameter;
using Door_of_Soul.Communication.ProxyServer.EndPoint;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Soul
{
    public static class SoulOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, VirtualSoul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceSoulOperationRequest(deviceId, sender.SoulId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(VirtualSoul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.EndPointSoulOperationRequest(sender.SoulId, operationCode, parameters);
        }

        public static void GetHexagramEntranceAvatar(VirtualSoul sender, int avatarId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetHexagramEntranceAvatarRequestParameterCode.AvatarId, avatarId },
            };
            SendEndPointOperationRequest(sender, SoulOperationCode.GetHexagramEntranceAvatar, operationRequestParameters);
        }
    }
}
