using Door_of_Soul.Communication.ProxyServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Answer
{
    public static class AnswerOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, TerminalAnswer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.AnswerOperationRequest(deviceId, sender.AnswerId, operationCode, parameters);
        }
    }
}
