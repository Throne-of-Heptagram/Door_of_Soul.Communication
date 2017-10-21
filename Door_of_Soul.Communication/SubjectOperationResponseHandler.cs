using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectOperationResponseHandler<TSubject> : ParameterChecker
    {
        protected SubjectOperationResponseHandler(Type typeOfOperationResponseParameterCode) : base(typeOfOperationResponseParameterCode)
        {
        }

        public virtual OperationReturnCode Handle(TSubject subject, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return CheckOperationReturn(subject, returnCode, operationMessage, parameters, out errorMessage);
        }
        protected virtual OperationReturnCode CheckOperationReturn(TSubject subject, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            switch (returnCode)
            {
                case OperationReturnCode.Successiful:
                    return CheckParameters(parameters, out errorMessage);
                default:
                    errorMessage = $"Unknown OperationReturnCode: {returnCode}, OperationMessage: {operationMessage}";
                    return OperationReturnCode.UndefinedError;
            }
        }
    }
}
