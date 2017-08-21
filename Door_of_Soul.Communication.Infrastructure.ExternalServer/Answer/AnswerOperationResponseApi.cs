using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer
{
    public static class AnswerOperationResponseApi
    {
        public static void SendOperationResponse(Core.Answer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.AnswerOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
