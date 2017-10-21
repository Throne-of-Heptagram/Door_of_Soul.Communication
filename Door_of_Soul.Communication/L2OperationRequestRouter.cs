using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L2OperationRequestRouter<TTerminal, TL2TerminalId, TOperationCode> : BasicOperationRequestRouter<TTerminal, TOperationCode>
    {
        protected Dictionary<TOperationCode, L2OperationRequestHandler<TTerminal, TL2TerminalId>> L2OperationTable { get; private set; } = new Dictionary<TOperationCode, L2OperationRequestHandler<TTerminal, TL2TerminalId>>();

        protected L2OperationRequestRouter(string subjectName) : base(subjectName)
        {
        }

        public OperationReturnCode Route(TTerminal terminal, TL2TerminalId l2TerminalId, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (L2OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = L2OperationTable[operationCode].Handle(terminal, l2TerminalId, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}L2OperationRequest Error, OperationCode: {operationCode} from {terminal}, L2TerminalId:{l2TerminalId}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}L2OperationRequest OperationCode:{operationCode} from {terminal}, L2TerminalId:{l2TerminalId}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
