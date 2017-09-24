using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.TrinityServer.Answer
{
    class AnswerOperationResponseRouter : SubjectOperationResponseRouter<TerminalAnswer, AnswerOperationCode>
    {
        public static AnswerOperationResponseRouter Instance { get; private set; } = new AnswerOperationResponseRouter();

        private AnswerOperationResponseRouter() : base("TrinityServerAnswer")
        {

        }
    }
}
