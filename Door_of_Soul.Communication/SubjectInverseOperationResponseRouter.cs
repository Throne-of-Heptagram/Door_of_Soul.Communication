using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseOperationResponseRouter<TTerminal, TSubject, TInverseOperationCode>
    {
        private string subjectName;
        protected Dictionary<TInverseOperationCode, SubjectInverseOperationResponseHandler<TTerminal, TSubject>> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, SubjectInverseOperationResponseHandler<TTerminal, TSubject>>();

        protected SubjectInverseOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TTerminal terminal, TSubject subject, TInverseOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                returnCode = OperationTable[operationCode].Handle(terminal, subject, returnCode, operationMessage, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}InverseOperationResponse Error, OperationCode: {operationCode} from:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationResponse OperationCode:{operationCode} from:{subject}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
