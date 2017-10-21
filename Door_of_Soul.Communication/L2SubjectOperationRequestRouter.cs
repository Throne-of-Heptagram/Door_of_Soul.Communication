using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L2SubjectOperationRequestRouter<TTerminal, TL2TerminalId, TSubject, TOperationCode> : SubjectOperationRequestRouter<TTerminal, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, L2SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TSubject>> L2OperationTable { get; private set; } = new Dictionary<TOperationCode, L2SubjectOperationRequestHandler<TTerminal, TL2TerminalId, TSubject>>();

        protected L2SubjectOperationRequestRouter(string subjectName) : base(subjectName)
        {
        }

        public OperationReturnCode Route(TTerminal terminal, TL2TerminalId l2TerminalId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (L2OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = L2OperationTable[operationCode].Handle(terminal, l2TerminalId, subject, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}L2OperationRequest Error, OperationCode: {operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}L2OperationRequest OperationCode:{operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, Subject:{subject}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
