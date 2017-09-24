using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectEventHandler<TSubject, TEventCode>
    {
        protected int CorrectParameterCount { get; private set; }

        protected SubjectEventHandler(Type typeOfEventParameterCode)
        {
            CorrectParameterCount = Enum.GetNames(typeOfEventParameterCode).Length;
        }

        public virtual bool Handle(TSubject subject, TEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return CheckParameters(parameters, out errorMessage);
        }
        protected virtual bool CheckParameters(Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (parameters.Count == CorrectParameterCount)
            {
                errorMessage = "";
                return true;
            }
            else
            {
                errorMessage = string.Format($"Parameter Count: {parameters.Count} Should be {CorrectParameterCount}");
                return false;
            }
        }
    }
}
