using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.TrinityServer.Device;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Answer
{
    public static class AnswerEventApi
    {
        public static void SendEvent(TerminalDevice terminal, TerminalAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.AnswerEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(TerminalAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.BroadcastAnswerEvent(target, eventCode, parameters);
        }
    }
}
