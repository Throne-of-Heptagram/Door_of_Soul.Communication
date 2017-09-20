using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.EventParameter;
using Door_of_Soul.Communication.ProxyServer.Device;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.ProxyServer.System
{
    public static class SystemEventApi
    {
        public static void SendEvent(TerminalDevice terminal, SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.SystemEvent(terminal, eventCode, parameters);
        }

        public static void SendBroadcastEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.BroadcastSystemEvent(eventCode, parameters);
        }

        public static void LoadProxyAnswer(TerminalDevice terminal, TerminalAnswer answer)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)LoadProxyAnswerParameterCode.AnswerId, answer.AnswerId },
                { (byte)LoadProxyAnswerParameterCode.AnswerName, answer.AnswerName },
                { (byte)LoadProxyAnswerParameterCode.SoulIds, answer.SoulIds.ToArray() }
            };
            SendEvent(terminal, SystemEventCode.LoadProxyAnswer, eventParameters);
        }
    }
}
