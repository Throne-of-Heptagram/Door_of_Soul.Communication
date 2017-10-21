using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicInverseOperationRequestHandler : ParameterChecker
    {
        public BasicInverseOperationRequestHandler(Type typeOfOperationRequestParameterCode) : base(typeOfOperationRequestParameterCode)
        {
        }

        public abstract void SendResponse(OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters);

        public virtual OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = CheckParameters(parameters, out errorMessage);
            if (returnCode != OperationReturnCode.Successiful)
            {
                SendResponse(returnCode, errorMessage, new Dictionary<byte, object>());
            }
            return returnCode;
        }
    }
}
