using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.ProxyServer.Answer
{
    class AnswerOperationResponseRouter : OperationResponseRouter<TerminalAnswer, AnswerOperationCode>
    {
        public static AnswerOperationResponseRouter Instance { get; private set; } = new AnswerOperationResponseRouter();

        private AnswerOperationResponseRouter()
        {
        }
    }
}
