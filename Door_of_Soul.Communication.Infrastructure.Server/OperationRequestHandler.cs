using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Server
{
    abstract class OperationRequestHandler<TSubject, TOperationCode>
    {
        protected TSubject Subject { get; private set; }
        private int correctParameterCount;
        protected OperationResponseSender<TOperationCode> SendResponse { get; private set; }

        public OperationRequestHandler(TSubject subject, int correctParameterCount, OperationResponseSender<TOperationCode> sendReponse)
        {
            Subject = subject;
            this.correctParameterCount = correctParameterCount;
            SendResponse = sendReponse;
        }

        public virtual bool Handle(TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (CheckParameterCount(parameters, out errorMessage))
            {
                return true;
            }
            else
            {
                SendResponse(operationCode, OperationReturnCode.ParameterCountError, errorMessage, new Dictionary<byte, object>());
                return false;
            }
        }
        private bool CheckParameterCount(Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (parameters.Count == correctParameterCount)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = $"Parameter Count: {parameters.Count}, should be {correctParameterCount}";
                return false;
            }
        }
    }
}
