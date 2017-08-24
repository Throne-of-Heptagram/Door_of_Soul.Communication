using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer
{
    class AnswerOperationResponseRouter : OperationResponseRouter<Core.Internal.EndPoint, Core.Answer, AnswerOperationCode>
    {
        public static AnswerOperationResponseRouter Instance { get; private set; } = new AnswerOperationResponseRouter();

        private AnswerOperationResponseRouter()
        {
        }
    }
}
