using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseEventHandler<TTerminal, TSubject> : ParameterChecker
    {
        protected SubjectInverseEventHandler(Type typeOfEventParameterCode) : base(typeOfEventParameterCode)
        {
        }

        public virtual OperationReturnCode Handle(TTerminal terminal, TSubject subject, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return CheckParameters(parameters, out errorMessage);
        }
    }
}
