using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client
{
    public abstract class OperationResponseRouter<TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationResponseHandler<TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationResponseHandler<TSubject, TOperationCode>>();

        public bool Route(TSubject subject, TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{typeof(TSubject)}OperationResponse Error: {operationCode} from {typeof(TSubject)}: {subject}\nErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationResponse:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
    }
}
