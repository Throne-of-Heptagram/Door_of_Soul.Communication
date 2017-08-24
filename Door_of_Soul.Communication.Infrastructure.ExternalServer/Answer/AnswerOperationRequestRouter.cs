using Door_of_Soul.Communication.Protocol.External.Answer;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer
{
    class AnswerOperationRequestRouter : OperationRequestRouter<Core.External.Device, Core.External.ExternalAnswer, AnswerOperationCode>
    {
        public static AnswerOperationRequestRouter Instance { get; private set; } = new AnswerOperationRequestRouter();

        private AnswerOperationRequestRouter()
        {

        }
    }
}
