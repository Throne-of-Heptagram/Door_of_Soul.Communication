using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseOperationRequestRouter<TSubject, TInverseOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TInverseOperationCode, SubjectInverseOperationRequestHandler<TSubject>> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, SubjectInverseOperationRequestHandler<TSubject>>();

        protected SubjectInverseOperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TSubject subject, TInverseOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = OperationTable[operationCode].Handle(subject, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}InverseOperationRequest Error, OperationCode: {operationCode}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationRequest OperationCode:{operationCode}, Subject:{subject}";
                return OperationReturnCode.UndefinedError;
            }
        }
    }
}
