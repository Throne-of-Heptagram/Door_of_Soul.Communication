using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure
{
    public abstract class OperationRequestRouter<TTerminal, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>>();

        public bool Route(TTerminal terminal, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                return OperationTable[operationCode].Handle(terminal, subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
    }
}
