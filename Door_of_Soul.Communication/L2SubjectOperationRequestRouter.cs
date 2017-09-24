using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L2SubjectOperationRequestRouter<TTerminal, TL2TerminalId, TSubject, TOperationCode> : SubjectOperationRequestRouter<TTerminal, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, L2SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TSubject, TOperationCode>> L2OperationTable { get; private set; } = new Dictionary<TOperationCode, L2SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TSubject, TOperationCode>>();

        protected L2SubjectOperationRequestRouter(string subjectName) : base(subjectName)
        {
        }

        public bool Route(TTerminal terminal, TL2TerminalId l2TerminalId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (L2OperationTable.ContainsKey(operationCode))
            {
                if (L2OperationTable[operationCode].Handle(terminal, l2TerminalId, subject, operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, Subject:{subject}";
                return false;
            }
        }
    }
}
