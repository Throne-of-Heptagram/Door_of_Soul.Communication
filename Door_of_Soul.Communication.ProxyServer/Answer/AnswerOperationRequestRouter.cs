using Door_of_Soul.Communication.Protocol.External.Answer;

namespace Door_of_Soul.Communication.ProxyServer.Answer
{
    class AnswerOperationRequestRouter : OperationRequestRouter<TerminalDevice, TerminalAnswer, AnswerOperationCode>
    {
        public static AnswerOperationRequestRouter Instance { get; private set; } = new AnswerOperationRequestRouter();

        private AnswerOperationRequestRouter()
        {

        }
    }
}
