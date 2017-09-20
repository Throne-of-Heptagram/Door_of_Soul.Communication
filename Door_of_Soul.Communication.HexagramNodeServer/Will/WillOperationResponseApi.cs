using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Communication.Protocol.Hexagram.Will.OperationResponseParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public static class WillOperationResponseApi
    {
        public static void SendOperationResponse(WillHexagramEntrance target, WillOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void GetWillSoul(WillHexagramEntrance terminal, OperationReturnCode operationReturnCode, string operationMessage, VirtualSoul soul)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetWillSoulResponseParameterCode.SoulId, soul.SoulId },
                { (byte)GetWillSoulResponseParameterCode.SoulName, soul.SoulName },
                { (byte)GetWillSoulResponseParameterCode.IsActivated, soul.IsActivated },
                { (byte)GetWillSoulResponseParameterCode.AnswerId, soul.AnswerId },
                { (byte)GetWillSoulResponseParameterCode.AvatarIds, soul.AvatarIds.ToArray() }
            };
            SendOperationResponse(terminal, WillOperationCode.GetWillSoul, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
