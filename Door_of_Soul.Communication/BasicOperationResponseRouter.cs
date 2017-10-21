using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicOperationResponseRouter<TOperationCode>
    {
        private string subjectName;
        protected Dictionary<TOperationCode, BasicOperationResponseHandler> OperationTable { get; private set; } = new Dictionary<TOperationCode, BasicOperationResponseHandler>();

        protected BasicOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                returnCode = OperationTable[operationCode].Handle(returnCode, operationMessage, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}OperationResponse Error OperationCode:{operationCode} HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationResponse OperationCode:{operationCode}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
