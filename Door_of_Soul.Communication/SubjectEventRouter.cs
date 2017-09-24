using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectEventRouter<TSubject, TEventCode>
    {
        private string subjectName;
        protected Dictionary<TEventCode, SubjectEventHandler<TSubject, TEventCode>> EventTable { get; private set; } = new Dictionary<TEventCode, SubjectEventHandler<TSubject, TEventCode>>();

        protected SubjectEventRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

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
                    errorMessage = $"{subjectName}Event Error, EventCode: {eventCode} from:{subject}, HandlerErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow {subjectName}Event EventCode:{eventCode} from:{subject}";
                return false;
            }
        }
    }
}
