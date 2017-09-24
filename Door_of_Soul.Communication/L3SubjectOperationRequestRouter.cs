using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L3SubjectOperationRequestRouter<TTerminal, TL2TerminalId, TL3TerminalId, TSubject, TOperationCode> : L2SubjectOperationRequestRouter<TTerminal, TL2TerminalId, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, L3SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TL3TerminalId, TSubject, TOperationCode>> L3OperationTable { get; private set; } = new Dictionary<TOperationCode, L3SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TL3TerminalId, TSubject, TOperationCode>>();

        protected L3SubjectOperationRequestRouter(string subjectName) : base(subjectName)
        {
        }

        public bool Route(TTerminal terminal, TL2TerminalId l2TerminalId, TL3TerminalId l3TerminalId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (L3OperationTable.ContainsKey(operationCode))
            {
                if (L3OperationTable[operationCode].Handle(terminal, l2TerminalId, l3TerminalId, subject, operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, L3TerminalId:{l3TerminalId}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, L3TerminalId:{l3TerminalId}, Subject:{subject}";
                return false;
            }
        }
    }
}
