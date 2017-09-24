using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class EventRouter<TEventCode>
    {
        private string subjectName;
        protected Dictionary<TEventCode, EventHandler<TEventCode>> EventTable { get; private set; } = new Dictionary<TEventCode, EventHandler<TEventCode>>();

        protected EventRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (EventTable.ContainsKey(eventCode))
            {
                if (EventTable[eventCode].Handle(eventCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{subjectName}Event Error, EventCode: {eventCode}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}Event EventCode:{eventCode}";
                return false;
            }
        }
    }
}
