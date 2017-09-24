using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L3OperationRequestRouter<TTerminal, TL2TerminalId, TL3TerminalId, TOperationCode> : L2OperationRequestRouter<TTerminal, TL2TerminalId, TOperationCode>
    {
        protected Dictionary<TOperationCode, L3OperationRequestHandler<TTerminal, TL2TerminalId, TL3TerminalId, TOperationCode>> L3OperationTable { get; private set; } = new Dictionary<TOperationCode, L3OperationRequestHandler<TTerminal, TL2TerminalId, TL3TerminalId, TOperationCode>>();

        protected L3OperationRequestRouter(string subjectName) : base(subjectName)
        {
        }

        public bool Route(TTerminal terminal, TL2TerminalId l2TerminalId, TL3TerminalId l3TerminalId, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (L3OperationTable.ContainsKey(operationCode))
            {
                if (L3OperationTable[operationCode].Handle(terminal, l2TerminalId, l3TerminalId, operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, L3TerminalId:{l3TerminalId}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, L3TerminalId:{l3TerminalId}";
                return false;
            }
        }
    }
}
