using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.TrinityServer.Answer
{
    class AnswerEventRouter : SubjectEventRouter<TerminalAnswer, AnswerEventCode>
    {
        public static AnswerEventRouter Instance { get; private set; } = new AnswerEventRouter();

        private AnswerEventRouter() : base("TrinityServerAnswer")
        {
        }
    }
}
