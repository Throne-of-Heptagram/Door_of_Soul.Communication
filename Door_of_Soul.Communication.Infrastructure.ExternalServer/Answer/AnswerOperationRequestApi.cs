using Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer
{
    public static class AnswerOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, Core.External.ExternalAnswer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.AnswerOperationRequest(deviceId, sender.AnswerId, operationCode, parameters);
        }
    }
}
