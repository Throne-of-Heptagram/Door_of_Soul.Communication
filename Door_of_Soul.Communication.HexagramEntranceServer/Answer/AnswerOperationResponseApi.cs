using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Answer
{
    public static class AnswerOperationResponseApi
    {
        public static void SendOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Answer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.AnswerOperationResponse(terminal, deviceId, target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
