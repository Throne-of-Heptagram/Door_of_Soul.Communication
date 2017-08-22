using Door_of_Soul.Communication.Protocol.External.Answer;

namespace Door_of_Soul.Communication.Infrastructure.Client.Answer
{
    class AnswerOperationResponseRouter : OperationResponseRouter<Core.Device, Core.Answer, AnswerOperationCode>
    {
        public static AnswerOperationResponseRouter Instance { get; private set; } = new AnswerOperationResponseRouter();

        private AnswerOperationResponseRouter()
        {
        }
    }
}
