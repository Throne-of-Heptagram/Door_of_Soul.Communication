using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L3SubjectOperationRequestRouter<TTerminal, TL2TerminalId, TL3TerminalId, TSubject, TOperationCode> : L2SubjectOperationRequestRouter<TTerminal, TL2TerminalId, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, L3SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TL3TerminalId, TSubject>> L3OperationTable { get; private set; } = new Dictionary<TOperationCode, L3SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TL3TerminalId, TSubject>>();

        protected L3SubjectOperationRequestRouter(string subjectName) : base(subjectName)
        {
        }

        public OperationReturnCode Route(TTerminal terminal, TL2TerminalId l2TerminalId, TL3TerminalId l3TerminalId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (L3OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = L3OperationTable[operationCode].Handle(terminal, l2TerminalId, l3TerminalId, subject, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}L3OperationRequest Error, OperationCode: {operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, L3TerminalId:{l3TerminalId}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}L3OperationRequest OperationCode:{operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, L3TerminalId:{l3TerminalId}, Subject:{subject}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
