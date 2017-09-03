using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Answer
{
    public static class AnswerOperationRequestApi
    {
        public static void SendOperationRequest(VirtualAnswer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.AnswerOperationRequest(sender.AnswerId, operationCode, parameters);
        }
    }
}
