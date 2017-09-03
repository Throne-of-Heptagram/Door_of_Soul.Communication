using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Answer
{
    class AnswerEventRouter : EventRouter<VirtualAnswer, AnswerEventCode>
    {
        public static AnswerEventRouter Instance { get; private set; } = new AnswerEventRouter();

        private AnswerEventRouter()
        {
        }
    }
}
