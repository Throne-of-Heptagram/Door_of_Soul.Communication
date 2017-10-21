using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicInverseOperationResponseRouter<TTerminal, TInverseOperationCode>
    {
        private string subjectName;
        protected Dictionary<TInverseOperationCode, BasicInverseOperationResponseHandler<TTerminal>> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, BasicInverseOperationResponseHandler<TTerminal>>();

        protected BasicInverseOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TTerminal terminal, TInverseOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                returnCode = OperationTable[operationCode].Handle(terminal, returnCode, operationMessage, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}InverseOperationResponse Error OperationCode:{operationCode} HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationResponse OperationCode:{operationCode}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
