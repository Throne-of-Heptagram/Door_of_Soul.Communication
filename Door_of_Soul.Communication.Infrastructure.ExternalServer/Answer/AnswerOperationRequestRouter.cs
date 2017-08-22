using Door_of_Soul.Communication.Protocol.External.Answer;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer
{
    class AnswerOperationRequestRouter : OperationRequestRouter<Core.Device, Core.Answer, AnswerOperationCode>
    {
        public static AnswerOperationRequestRouter Instance { get; private set; } = new AnswerOperationRequestRouter();

        private AnswerOperationRequestRouter()
        {

        }
    }
}
