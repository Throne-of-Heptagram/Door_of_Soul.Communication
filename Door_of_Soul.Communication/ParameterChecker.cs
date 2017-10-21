using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class ParameterChecker
    {
        protected int CorrectParameterCount { get; private set; }

        protected ParameterChecker(Type typeOfEventParameterCode)
        {
            CorrectParameterCount = Enum.GetNames(typeOfEventParameterCode).Length;
        }

        protected virtual OperationReturnCode CheckParameters(Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (parameters.Count == CorrectParameterCount)
            {
                errorMessage = "";
                return OperationReturnCode.Successiful;
            }
            else
            {
                errorMessage = string.Format($"Parameter Count: {parameters.Count} Should be {CorrectParameterCount}");
                return OperationReturnCode.ParameterCountError;
            }
        }
    }
}
