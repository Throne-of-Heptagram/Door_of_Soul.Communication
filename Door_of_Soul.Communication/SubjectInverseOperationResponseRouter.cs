using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseOperationResponseRouter<TTerminal, TSubject, TInverseOperationCode>
    {
        private string subjectName;
        protected Dictionary<TInverseOperationCode, SubjectInverseOperationResponseHandler<TTerminal, TSubject, TInverseOperationCode>> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, SubjectInverseOperationResponseHandler<TTerminal, TSubject, TInverseOperationCode>>();

        protected SubjectInverseOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TTerminal terminal, TSubject subject, TInverseOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(terminal, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}InverseOperationResponse Error, OperationCode: {operationCode} from:{subject}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationResponse OperationCode:{operationCode} from:{subject}";
                return false;
            }
        }
    }
}
