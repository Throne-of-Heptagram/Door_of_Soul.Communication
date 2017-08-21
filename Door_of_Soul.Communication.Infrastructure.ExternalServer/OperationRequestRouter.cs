using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer
{
    public abstract class OperationRequestRouter<TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationRequestHandler<TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TSubject, TOperationCode>>();

        public bool Route(TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                return OperationTable[operationCode].Handle(subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
    }
}
