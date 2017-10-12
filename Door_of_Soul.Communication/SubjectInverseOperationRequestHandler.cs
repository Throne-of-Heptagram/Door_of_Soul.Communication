using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseOperationRequestHandler<TSubject, TInverseOperationCode>
    {
        protected int CorrectParameterCount { get; private set; }

        public SubjectInverseOperationRequestHandler(Type typeOfOperationRequestParameterCode)
        {
            CorrectParameterCount = Enum.GetNames(typeOfOperationRequestParameterCode).Length;
        }

        public abstract void SendResponse(TSubject target, TInverseOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters);

        public virtual bool Handle(TSubject requester, TInverseOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (CheckParameterCount(parameters, out errorMessage))
            {
                return true;
            }
            else
            {
                SendResponse(requester, operationCode, OperationReturnCode.ParameterCountError, errorMessage, new Dictionary<byte, object>());
                return false;
            }
        }
        private bool CheckParameterCount(Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (parameters.Count == CorrectParameterCount)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = $"Parameter Count: {parameters.Count}, should be {CorrectParameterCount}";
                return false;
            }
        }
    }
}
