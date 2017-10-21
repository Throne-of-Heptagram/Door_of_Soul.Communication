using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class BasicEventRouter<TEventCode>
    {
        private string subjectName;
        protected Dictionary<TEventCode, BasicEventHandler> EventTable { get; private set; } = new Dictionary<TEventCode, BasicEventHandler>();

        protected BasicEventRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (EventTable.ContainsKey(eventCode))
            {
                OperationReturnCode returnCode = EventTable[eventCode].Handle(parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}Event Error, EventCode: {eventCode}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}Event EventCode:{eventCode}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
