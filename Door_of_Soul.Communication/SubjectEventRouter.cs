using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectEventRouter<TSubject, TEventCode>
    {
        private string subjectName;
        protected Dictionary<TEventCode, SubjectEventHandler<TSubject>> EventTable { get; private set; } = new Dictionary<TEventCode, SubjectEventHandler<TSubject>>();

        protected SubjectEventRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TSubject subject, TEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (EventTable.ContainsKey(eventCode))
            {
                OperationReturnCode returnCode = EventTable[eventCode].Handle(subject, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}Event Error, EventCode: {eventCode} from:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}Event EventCode:{eventCode} from:{subject}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
