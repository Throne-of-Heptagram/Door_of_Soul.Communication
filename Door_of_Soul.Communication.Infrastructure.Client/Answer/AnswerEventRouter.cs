using Door_of_Soul.Communication.Protocol.External.Answer;

namespace Door_of_Soul.Communication.Infrastructure.Client.Answer
{
    class AnswerEventRouter : EventRouter<Core.Answer, AnswerEventCode>
    {
        public static AnswerEventRouter Instance { get; private set; } = new AnswerEventRouter();

        private AnswerEventRouter()
        {
        }
    }
}
