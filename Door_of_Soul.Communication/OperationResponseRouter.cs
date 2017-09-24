using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class OperationResponseRouter<TOperationCode>
    {
        private string subjectName;
        protected Dictionary<TOperationCode, OperationResponseHandler<TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationResponseHandler<TOperationCode>>();

        protected OperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}OperationResponse Error OperationCode:{operationCode} HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationResponse OperationCode:{operationCode}";
                return false;
            }
        }
    }
}
