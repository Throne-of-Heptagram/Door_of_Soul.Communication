using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class OperationRequestRouter<TTerminal, TOperationCode>
    {
        private string subjectName;
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TOperationCode>>();

        protected OperationRequestRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TTerminal terminal, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                return OperationTable[operationCode].Handle(terminal, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {subjectName}OperationRequest:{operationCode} from {subjectName}";
                return false;
            }
        }
    }

    public abstract class OperationRequestRouter<TTerminal, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>>();

        public bool Route(TTerminal terminal, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                return OperationTable[operationCode].Handle(terminal, subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
    }

    public abstract class OperationRequestRouter<TTerminal, TDeviceId, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TDeviceId, TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TDeviceId, TSubject, TOperationCode>>();

        public bool Route(TTerminal terminal, TDeviceId deviceId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                return OperationTable[operationCode].Handle(terminal, deviceId, subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
    }

    public abstract class OperationRequestRouter<TTerminal, TEndPointId, TDeviceId, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TEndPointId, TDeviceId, TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TEndPointId, TDeviceId, TSubject, TOperationCode>>();

        public bool Route(TTerminal terminal, TEndPointId endPointId, TDeviceId deviceId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                return OperationTable[operationCode].Handle(terminal, endPointId, deviceId, subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
    }
}
