using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseOperationRequestHandler<TSubject> : ParameterChecker
    {
        public SubjectInverseOperationRequestHandler(Type typeOfOperationRequestParameterCode) : base(typeOfOperationRequestParameterCode)
        {
        }

        public abstract void SendResponse(TSubject target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters);

        public virtual OperationReturnCode Handle(TSubject requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = CheckParameters(parameters, out errorMessage);
            if (returnCode != OperationReturnCode.Successiful)
            {
                SendResponse(requester, returnCode, errorMessage, new Dictionary<byte, object>());
            }
            return returnCode;
        }
    }
}
