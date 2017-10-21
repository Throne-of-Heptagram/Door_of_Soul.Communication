using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicForwardOperationHandler : ParameterChecker
    {
        public BasicForwardOperationHandler(Type typeOfOperationRequestParameterCode) : base(typeOfOperationRequestParameterCode)
        {
        }

        public virtual OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            return CheckParameters(parameters, out errorMessage);
        }
    }
}
