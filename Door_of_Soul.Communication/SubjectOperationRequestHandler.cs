using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectOperationRequestHandler<TTerminal, TSubject> : ParameterChecker
    {
        public SubjectOperationRequestHandler(Type typeOfOperationRequestParameterCode) : base(typeOfOperationRequestParameterCode)
        {

        }

        public abstract void SendResponse(TTerminal terminal, TSubject target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters);

        public virtual OperationReturnCode Handle(TTerminal terminal, TSubject requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = CheckParameters(parameters, out errorMessage);
            if (returnCode != OperationReturnCode.Successiful)
            {
                SendResponse(terminal, requester, returnCode, errorMessage, new Dictionary<byte, object>());
            }
            return returnCode;
        }
    }
}
