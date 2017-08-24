using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class EventRouter<TSubject, TEventCode>
    {
        protected Dictionary<TEventCode, EventHandler<TSubject, TEventCode>> EventTable { get; private set; } = new Dictionary<TEventCode, EventHandler<TSubject, TEventCode>>();

        public bool Route(TSubject subject, TEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (EventTable.ContainsKey(eventCode))
            {
                if (EventTable[eventCode].Handle(subject, eventCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"{typeof(TSubject)}Event Error: {eventCode} from {typeof(TSubject)}: {subject}\nErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}Event:{eventCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
    }
}
