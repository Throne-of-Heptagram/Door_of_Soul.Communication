using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Communication.Protocol.External.Answer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Answer
{
    public static class AnswerEventApi
    {
        public static void SendEvent(TerminalAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.AnswerEvent(target, eventCode, parameters);
        }
    }
}
