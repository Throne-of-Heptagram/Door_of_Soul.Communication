using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Answer
{
    public static class AnswerOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, int answerId, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.AnswerOperationResponse(terminal, answerId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
