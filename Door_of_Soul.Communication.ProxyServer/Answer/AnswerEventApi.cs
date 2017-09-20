using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Answer.EventParameter;
using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.ProxyServer.Answer
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

        public static void LoadProxySoul(TerminalDevice terminal, TerminalAnswer target, VirtualSoul soul)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)LoadProxySoulParameterCode.SoulId, soul.SoulId },
                { (byte)LoadProxySoulParameterCode.SoulName, soul.SoulName },
                { (byte)LoadProxySoulParameterCode.IsActivated, soul.IsActivated },
                { (byte)LoadProxySoulParameterCode.AnswerId, soul.AnswerId },
                { (byte)LoadProxySoulParameterCode.AvatarIds, soul.AvatarIds.ToArray() }
            };
            SendEvent(terminal, target, AnswerEventCode.LoadProxySoul, eventParameters);
        }
    }
}
