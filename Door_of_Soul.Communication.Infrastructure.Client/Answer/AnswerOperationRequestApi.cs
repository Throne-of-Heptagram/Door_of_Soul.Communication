using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Answer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Answer
{
    public static class AnswerOperationRequestApi
    {
        public static void SendOperationRequest(Core.Answer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.AnswerOperationRequest(sender.AnswerId, operationCode, parameters);
        }
    }
}
