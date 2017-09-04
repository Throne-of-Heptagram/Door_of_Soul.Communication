using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Avatar
{
    public static class AvatarOperationResponseApi
    {
        public static void SendOperationResponse(TerminalEndPoint terminal, int deviceId, VirtualAvatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.AvatarOperationResponse(terminal, deviceId, target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
