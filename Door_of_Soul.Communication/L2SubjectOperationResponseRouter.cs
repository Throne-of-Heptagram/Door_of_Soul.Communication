using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L2SubjectOperationResponseRouter<TSubject, TL2TerminalId, TOperationCode>
    {
        private string subjectName;
        protected Dictionary<TOperationCode, L2SubjectOperationResponseHandler<TSubject, TL2TerminalId, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, L2SubjectOperationResponseHandler<TSubject, TL2TerminalId, TOperationCode>>();

        protected L2SubjectOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TSubject subject, TL2TerminalId l2TerminalId, TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(subject, l2TerminalId, operationCode, returnCode, operationMessage, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationResponse Error, OperationCode: {operationCode} from:{subject}, L2TerminalId:{l2TerminalId}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationResponse OperationCode:{operationCode} from:{subject}, L2TerminalId:{l2TerminalId}";
                return false;
            }
        }
    }
}
