using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Answer
{
    public static class AnswerEventApi
    {
        public static void SendEvent(Core.Answer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.AnswerEvent(target, eventCode, parameters);
        }
    }
}
