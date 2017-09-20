using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationResponseParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneOperationResponseApi
    {
        public static void SendOperationResponse(ThroneHexagramEntrance target, ThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void GetThroneAnswer(ThroneHexagramEntrance terminal, OperationReturnCode operationReturnCode, string operationMessage, VirtualAnswer answer)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetThroneAnswerResponseParameterCode.AnswerId, answer.AnswerId },
                { (byte)GetThroneAnswerResponseParameterCode.AnswerName, answer.AnswerName },
                { (byte)GetThroneAnswerResponseParameterCode.SoulIds, answer.SoulIds.ToArray() }
            };
            SendOperationResponse(terminal, ThroneOperationCode.GetThroneAnswer, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
