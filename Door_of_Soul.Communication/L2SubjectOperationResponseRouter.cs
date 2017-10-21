using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L2SubjectOperationResponseRouter<TSubject, TL2TerminalId, TOperationCode>
    {
        private string subjectName;
        protected Dictionary<TOperationCode, L2SubjectOperationResponseHandler<TSubject, TL2TerminalId>> OperationTable { get; private set; } = new Dictionary<TOperationCode, L2SubjectOperationResponseHandler<TSubject, TL2TerminalId>>();

        protected L2SubjectOperationResponseRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TSubject subject, TL2TerminalId l2TerminalId, TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                returnCode = OperationTable[operationCode].Handle(subject, l2TerminalId, returnCode, operationMessage, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}L2OperationResponse Error, OperationCode: {operationCode} from:{subject}, L2TerminalId:{l2TerminalId}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}L2OperationResponse OperationCode:{operationCode} from:{subject}, L2TerminalId:{l2TerminalId}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
