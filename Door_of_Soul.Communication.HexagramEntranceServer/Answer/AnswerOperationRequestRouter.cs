using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Core.HexagramEntranceServer;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Answer
{
    class AnswerOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, int, VirtualAnswer, AnswerOperationCode>
    {
        public static AnswerOperationRequestRouter Instance { get; private set; } = new AnswerOperationRequestRouter();

        private AnswerOperationRequestRouter()
        {

        }
    }
}
