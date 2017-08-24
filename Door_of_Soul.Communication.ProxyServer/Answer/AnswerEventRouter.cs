using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.ProxyServer.Answer
{
    class AnswerEventRouter : EventRouter<TerminalAnswer, AnswerEventCode>
    {
        public static AnswerEventRouter Instance { get; private set; } = new AnswerEventRouter();

        private AnswerEventRouter()
        {
        }
    }
}
