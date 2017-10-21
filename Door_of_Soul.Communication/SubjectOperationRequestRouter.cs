using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectOperationRequestRouter<TTerminal, TSubject, TOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TOperationCode, SubjectOperationRequestHandler<TTerminal, TSubject>> OperationTable { get; private set; } = new Dictionary<TOperationCode, SubjectOperationRequestHandler<TTerminal, TSubject>>();

        protected SubjectOperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TTerminal terminal, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = OperationTable[operationCode].Handle(terminal, subject, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}OperationRequest Error, OperationCode: {operationCode} from {terminal}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest OperationCode:{operationCode} from {terminal}, Subject:{subject}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
