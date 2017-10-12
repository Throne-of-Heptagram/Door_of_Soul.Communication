using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class InverseOperationResponseRouter<TTerminal, TInverseOperationCode>
    {
        private string subjectName;
        protected Dictionary<TInverseOperationCode, InverseOperationResponseHandler<TTerminal, TInverseOperationCode>> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, InverseOperationResponseHandler<TTerminal, TInverseOperationCode>>();

        protected InverseOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TTerminal terminal, TInverseOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(terminal, operationCode, returnCode, operationMessage, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}InverseOperationResponse Error OperationCode:{operationCode} HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationResponse OperationCode:{operationCode}";
                return false;
            }
        }
    }
}
