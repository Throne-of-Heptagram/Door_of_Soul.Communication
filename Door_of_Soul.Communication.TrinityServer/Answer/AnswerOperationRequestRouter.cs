using Door_of_Soul.Communication.Protocol.External.Answer;

namespace Door_of_Soul.Communication.TrinityServer.Answer
{
    class AnswerOperationRequestRouter : SubjectOperationRequestRouter<TerminalDevice, TerminalAnswer, AnswerOperationCode>
    {
        public static AnswerOperationRequestRouter Instance { get; private set; } = new AnswerOperationRequestRouter();

        private AnswerOperationRequestRouter() : base("TrinityServerAnswer")
        {

        }
    }
}
