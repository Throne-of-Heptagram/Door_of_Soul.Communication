using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicInverseEventRouter<TTerminal, TInverseEventCode>
    {
        private string subjectName;
        protected Dictionary<TInverseEventCode, BasicInverseEventHandler<TTerminal>> EventTable { get; private set; } = new Dictionary<TInverseEventCode, BasicInverseEventHandler<TTerminal>>();

        protected BasicInverseEventRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TTerminal terminal, TInverseEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (EventTable.ContainsKey(eventCode))
            {
                OperationReturnCode returnCode = EventTable[eventCode].Handle(terminal, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}InverseEvent Error, EventCode: {eventCode}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseEvent EventCode:{eventCode}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
