using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class InverseOperationRequestRouter<TInverseOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TInverseOperationCode, InverseOperationRequestHandler<TInverseOperationCode>> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, InverseOperationRequestHandler<TInverseOperationCode>>();

        protected InverseOperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TInverseOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}InverseOperationRequest Error, OperationCode: {operationCode}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationRequest OperationCode:{operationCode}";
                return false;
            }
        }
    }
}
