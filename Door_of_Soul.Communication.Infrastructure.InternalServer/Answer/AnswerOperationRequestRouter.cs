using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.Answer
{
    class AnswerOperationRequestRouter : OperationRequestRouter<Core.Internal.EndPoint, int, Core.Answer, AnswerOperationCode>
    {
        public static AnswerOperationRequestRouter Instance { get; private set; } = new AnswerOperationRequestRouter();

        private AnswerOperationRequestRouter()
        {

        }
    }
}
