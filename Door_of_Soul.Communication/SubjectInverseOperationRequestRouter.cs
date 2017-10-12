using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseOperationRequestRouter<TSubject, TInverseOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TInverseOperationCode, SubjectInverseOperationRequestHandler<TSubject, TInverseOperationCode>> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, SubjectInverseOperationRequestHandler<TSubject, TInverseOperationCode>>();

        protected SubjectInverseOperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TSubject subject, TInverseOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                if (OperationTable[operationCode].Handle(subject, operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}InverseOperationRequest Error, OperationCode: {operationCode}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationRequest OperationCode:{operationCode}, Subject:{subject}";
                return false;
            }
        }
    }
}
