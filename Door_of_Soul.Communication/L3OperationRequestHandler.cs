using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class L3OperationRequestHandler<TTerminal, TL2TerminalId, TL3TerminalId> : ParameterChecker
    {
        public L3OperationRequestHandler(Type typeOfOperationRequestParameterCode) : base(typeOfOperationRequestParameterCode)
        {
        }

        public abstract void SendResponse(TTerminal terminal, TL2TerminalId l2TerminalId, TL3TerminalId l3TerminalId, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters);

        public virtual OperationReturnCode Handle(TTerminal terminal, TL2TerminalId l2TerminalId, TL3TerminalId l3TerminalId, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = CheckParameters(parameters, out errorMessage);
            if (returnCode != OperationReturnCode.Successiful)
            {
                SendResponse(terminal, l2TerminalId, l3TerminalId, returnCode, errorMessage, new Dictionary<byte, object>());
            }
            return returnCode;
        }
    }
}
