using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class OperationRequestRouter<TTerminal, TOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TOperationCode>>();

        protected OperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TTerminal terminal, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if(OperationTable[operationCode].Handle(terminal, operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}";
                return false;
            }
        }
    }
}
