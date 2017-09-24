using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.TrinityServer.Device;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Avatar
{
    public static class AvatarOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, int avatarId, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.AvatarOperationResponse(terminal, avatarId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
