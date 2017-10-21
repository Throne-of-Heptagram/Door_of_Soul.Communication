﻿using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicInverseOperationResponseHandler<TTerminal> : ParameterChecker
    {
        protected BasicInverseOperationResponseHandler(Type typeOfOperationResponseParameterCode) : base(typeOfOperationResponseParameterCode)
        {
        }

        public virtual OperationReturnCode Handle(TTerminal terminal, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return CheckOperationReturn(returnCode, operationMessage, parameters, out errorMessage);
        }
        protected virtual OperationReturnCode CheckOperationReturn(OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            switch (returnCode)
            {
                case OperationReturnCode.Successiful:
                    return CheckParameters(parameters, out errorMessage);
                default:
                    errorMessage = $"Unknown OperationReturnCode: {returnCode}, OperationMessage: {operationMessage}";
                    return OperationReturnCode.UndefinedError;
            }
        }
    }
}
