using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.Answer
{
    class AnswerOperationResponseRouter : OperationResponseRouter<VirtualAnswer, AnswerOperationCode>
    {
        public static AnswerOperationResponseRouter Instance { get; private set; } = new AnswerOperationResponseRouter();

        private AnswerOperationResponseRouter()
        {
        }
    }
}
