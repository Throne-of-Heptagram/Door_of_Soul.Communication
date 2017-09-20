using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.Soul.OperationResponseParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Soul
{
    public static class SoulOperationResponseApi
    {
        public static void SendDeviceOperationResponse(TerminalEndPoint terminal, int deviceId, VirtualSoul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.DeviceSoulOperationResponse(terminal, deviceId, target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void SendEndPointOperationResponse(TerminalEndPoint terminal, VirtualSoul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.EndPointSoulOperationResponse(terminal, target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void GetHexagramEntranceAvatar(TerminalEndPoint terminal, VirtualSoul target, OperationReturnCode operationReturnCode, string operationMessage, VirtualAvatar avatar)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetHexagramEntranceAvatarResponseParameterCode.AvatarId, avatar.AvatarId },
                { (byte)GetHexagramEntranceAvatarResponseParameterCode.EntityId, avatar.EntityId },
                { (byte)GetHexagramEntranceAvatarResponseParameterCode.AvatarName, avatar.AvatarName },
                { (byte)GetHexagramEntranceAvatarResponseParameterCode.SoulIds, avatar.SoulIds.ToArray() }
            };
            SendEndPointOperationResponse(terminal, target, SoulOperationCode.GetHexagramEntranceAvatar, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
