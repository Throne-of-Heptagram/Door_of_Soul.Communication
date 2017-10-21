using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class SubjectInverseEventRouter<TTerminal, TSubject, TInverseEventCode>
    {
        private string subjectName;
        protected Dictionary<TInverseEventCode, SubjectInverseEventHandler<TTerminal, TSubject>> EventTable { get; private set; } = new Dictionary<TInverseEventCode, SubjectInverseEventHandler<TTerminal, TSubject>>();

        protected SubjectInverseEventRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public OperationReturnCode Route(TTerminal terminal, TSubject subject, TInverseEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (EventTable.ContainsKey(eventCode))
            {
                OperationReturnCode returnCode = EventTable[eventCode].Handle(terminal, subject, parameters, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    errorMessage = $"{subjectName}InverseEvent Error, EventCode: {eventCode}, Subject:{subject}, HandlerErrorMessage: {errorMessage}";
                }
                return returnCode;
            }
            else
            {
                errorMessage = $"Unknow {subjectName}InverseEvent EventCode:{eventCode}, Subject:{subject}";
                return OperationReturnCode.NotExisted;
            }
        }
    }
}
