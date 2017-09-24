﻿using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectOperationRequestHandler<TTerminal, TSubject, TOperationCode>
    {
        protected int CorrectParameterCount { get; private set; }

        public SubjectOperationRequestHandler(Type typeOfOperationRequestParameterCode)
        {
            CorrectParameterCount = Enum.GetNames(typeOfOperationRequestParameterCode).Length;
        }

        public abstract void SendResponse(TTerminal terminal, TSubject target, TOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters);

        public virtual bool Handle(TTerminal terminal, TSubject requester, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (CheckParameterCount(parameters, out errorMessage))
            {
                return true;
            }
            else
            {
                SendResponse(terminal, requester, operationCode, OperationReturnCode.ParameterCountError, errorMessage, new Dictionary<byte, object>());
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
