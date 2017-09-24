using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectOperationRequestRouter<TTerminal, TSubject, TOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TOperationCode, SubjectOperationRequestHandler<TTerminal, TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, SubjectOperationRequestHandler<TTerminal, TSubject, TOperationCode>>();

        protected SubjectOperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TTerminal terminal, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(terminal, subject, operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}, Subject:{subject}";
                return false;
            }
        }
    }
}
