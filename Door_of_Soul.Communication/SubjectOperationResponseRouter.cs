using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectOperationResponseRouter<TSubject, TOperationCode>
    {
        private string subjectName;
        protected Dictionary<TOperationCode, SubjectOperationResponseHandler<TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, SubjectOperationResponseHandler<TSubject, TOperationCode>>();

        protected SubjectOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TSubject subject, TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationResponse Error, OperationCode: {operationCode} from:{subject}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationResponse OperationCode:{operationCode} from:{subject}";
                return false;
            }
        }
    }
}
