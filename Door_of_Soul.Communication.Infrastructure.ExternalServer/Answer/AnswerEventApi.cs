using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.Answer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer
{
    public static class AnswerEventApi
    {
        public static void SendEvent(Core.External.ExternalAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.AnswerEvent(target, eventCode, parameters);
        }
    }
}
