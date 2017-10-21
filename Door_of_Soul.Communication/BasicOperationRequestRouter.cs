using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicOperationRequestRouter<TTerminal, TOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TOperationCode, BasicOperationRequestHandler<TTerminal>> OperationTable { get; private set; } = new Dictionary<TOperationCode, BasicOperationRequestHandler<TTerminal>>();

        protected BasicOperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TTerminal terminal, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = OperationTable[operationCode].Handle(terminal, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
