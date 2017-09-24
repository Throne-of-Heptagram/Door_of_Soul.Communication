using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L2OperationRequestRouter<TTerminal, TL2TerminalId, TOperationCode> : OperationRequestRouter<TTerminal, TOperationCode>
    {
        protected Dictionary<TOperationCode, L2OperationRequestHandler<TTerminal, TL2TerminalId, TOperationCode>> L2OperationTable { get; private set; } = new Dictionary<TOperationCode, L2OperationRequestHandler<TTerminal, TL2TerminalId, TOperationCode>>();

        protected L2OperationRequestRouter(string subjectName) : base(subjectName)
        {
        }

        public bool Route(TTerminal terminal, TL2TerminalId l2TerminalId, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (L2OperationTable.ContainsKey(operationCode))
            {
                if (L2OperationTable[operationCode].Handle(terminal, l2TerminalId, operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}, L2TerminalId:{l2TerminalId}";
                return false;
            }
        }
    }
}
