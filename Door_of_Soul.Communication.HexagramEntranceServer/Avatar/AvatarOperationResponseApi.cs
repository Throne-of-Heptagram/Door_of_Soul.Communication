using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Avatar
{
    public static class AvatarOperationResponseApi
    {
        public static void SendDeviceOperationResponse(TerminalEndPoint terminal, int deviceId, VirtualAvatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.DeviceAvatarOperationResponse(terminal, deviceId, target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void SendEndPointOperationResponse(TerminalEndPoint terminal, VirtualAvatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.EndPointAvatarOperationResponse(terminal, target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
