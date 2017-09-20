using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Answer.OperationResponseParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Answer
{
    public static class AnswerOperationResponseApi
    {
        public static void SendDeviceOperationResponse(TerminalEndPoint terminal, int deviceId, VirtualAnswer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.DeviceAnswerOperationResponse(terminal, deviceId, target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void SendEndPointOperationResponse(TerminalEndPoint terminal, VirtualAnswer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.EndPointAnswerOperationResponse(terminal, target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void GetHexagramEntranceSoul(TerminalEndPoint terminal, VirtualAnswer target, OperationReturnCode operationReturnCode, string operationMessage, VirtualSoul soul)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetHexagramEntranceSoulResponseParameterCode.SoulId, soul.SoulId },
                { (byte)GetHexagramEntranceSoulResponseParameterCode.SoulName, soul.SoulName },
                { (byte)GetHexagramEntranceSoulResponseParameterCode.IsActivated, soul.IsActivated },
                { (byte)GetHexagramEntranceSoulResponseParameterCode.AnswerId, soul.AnswerId },
                { (byte)GetHexagramEntranceSoulResponseParameterCode.AvatarIds, soul.AvatarIds.ToArray() }
            };
            SendEndPointOperationResponse(terminal, target, AnswerOperationCode.GetHexagramEntranceSoul, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
