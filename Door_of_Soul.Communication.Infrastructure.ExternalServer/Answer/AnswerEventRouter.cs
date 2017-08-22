using Door_of_Soul.Communication.Protocol.Internal.Answer;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer
{
    class AnswerEventRouter : EventRouter<Core.Answer, AnswerEventCode>
    {
        public static AnswerEventRouter Instance { get; private set; } = new AnswerEventRouter();

        private AnswerEventRouter()
        {
        }
    }
}
