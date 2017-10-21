using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicForwardOperationRouter<TForwardOperationCode>
    {
        private string subjectName;
        protected Dictionary<TForwardOperationCode, BasicForwardOperationHandler> OperationTable { get; private set; } = new Dictionary<TForwardOperationCode, BasicForwardOperationHandler>();

        protected BasicForwardOperationRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TForwardOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = OperationTable[operationCode].Handle(parameters, out errorMessage);
                if(returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}ForwardOperationRequest Error, ForwardOperationCode: {operationCode}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}ForwardOperation ForwardOperationCode:{operationCode}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
