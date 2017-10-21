using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectOperationResponseRouter<TSubject, TOperationCode>
    {
        private string subjectName;
        protected Dictionary<TOperationCode, SubjectOperationResponseHandler<TSubject>> OperationTable { get; private set; } = new Dictionary<TOperationCode, SubjectOperationResponseHandler<TSubject>>();

        protected SubjectOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TSubject subject, TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                returnCode = OperationTable[operationCode].Handle(subject, returnCode, operationMessage, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}OperationResponse Error, OperationCode: {operationCode} from:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationResponse OperationCode:{operationCode} from:{subject}";
                return OperationReturnCode.UndefinedError;
            }
        }
    }
}
