using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client
{
    public abstract class EventHandler<TSubject, TEventCode>
    {
        protected int CorrectParameterCount { get; private set; }

        protected EventHandler(Type typeOfEventParameterCode)
        {
            CorrectParameterCount = Enum.GetNames(typeOfEventParameterCode).Length;
        }

        internal virtual bool Handle(TSubject subject, TEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return CheckParameters(parameters, out errorMessage);
        }
        internal virtual bool CheckParameters(Dictionary<byte, object> parameters, out string errorMessage)
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
