using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Core.HexagramEntranceServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Answer
{
    public static class AnswerEventApi
    {
        public static void SendEvent(TerminalEndPoint terminal, VirtualAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.AnswerEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.BroadcastAnswerEvent(target, eventCode, parameters);
        }
    }
}
