using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Answer
{
    class AnswerOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, int, Core.Answer, AnswerOperationCode>
    {
        public static AnswerOperationRequestRouter Instance { get; private set; } = new AnswerOperationRequestRouter();

        private AnswerOperationRequestRouter()
        {

        }
    }
}
