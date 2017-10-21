using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.InverseOperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    public static class ThroneInverseOperationResponseApi
    {
        public static void SendOperationResponse(ThroneInverseOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneCommunicationService.Instance.SendInverseOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void AssignAnswer(OperationReturnCode returnCode, string operationMessage, int trinityServerEndPointId, int answerId, string answerAccessToken)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AssignAnswerResponseParameterCode.TrinityServerEndPointId, trinityServerEndPointId },
                { (byte)AssignAnswerResponseParameterCode.AnswerId, answerId },
                { (byte)AssignAnswerResponseParameterCode.AnswerAccessToken, answerAccessToken }
            };
            SendOperationResponse(ThroneInverseOperationCode.AssignAnswer, returnCode, operationMessage, operationResponseParameters);
        }
    }
}
