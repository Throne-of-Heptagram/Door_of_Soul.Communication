using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicInverseOperationRequestRouter<TInverseOperationCode>
    {
        protected readonly string subjectName;
        protected Dictionary<TInverseOperationCode, BasicInverseOperationRequestHandler> OperationTable { get; private set; } = new Dictionary<TInverseOperationCode, BasicInverseOperationRequestHandler>();

        protected BasicInverseOperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TInverseOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                OperationReturnCode returnCode = OperationTable[operationCode].Handle(parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}InverseOperationRequest Error, OperationCode: {operationCode}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseOperationRequest OperationCode:{operationCode}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
