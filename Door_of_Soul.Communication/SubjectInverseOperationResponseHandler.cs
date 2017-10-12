using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseOperationResponseHandler<TTerminal, TSubject, TInverseOperationCode>
    {
        protected int CorrectParameterCount { get; private set; }

        protected SubjectInverseOperationResponseHandler(Type typeOfOperationResponseParameterCode)
        {
            CorrectParameterCount = Enum.GetNames(typeOfOperationResponseParameterCode).Length;
        }

        public virtual bool Handle(TTerminal terminal, TSubject subject, TInverseOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return CheckOperationReturn(returnCode, operationMessage, parameters, out errorMessage);
        }
        protected virtual bool CheckOperationReturn(OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            switch (returnCode)
            {
                case OperationReturnCode.Successiful:
                    return CheckParameters(parameters, out errorMessage);
                default:
                    errorMessage = $"Unknown OperationReturnCode: {returnCode}, OperationMessage: {operationMessage}";
                    return false;
            }
        }
        protected virtual bool CheckParameters(Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (parameters.Count != CorrectParameterCount)
            {
                errorMessage = $"Parameter Count: {parameters.Count} Should be {CorrectParameterCount}";
                return false;
            }
            else
            {
                errorMessage = "";
                return true;
            }
        }
    }
}
