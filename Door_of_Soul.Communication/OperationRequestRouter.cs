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

    public abstract class OperationRequestRouter<TTerminal, TSubterminalId, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubterminalId, TSubject, TOperationCode>> SubterminalOperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubterminalId, TSubject, TOperationCode>>();
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>>();

        public bool Route(TTerminal terminal, TSubterminalId subterminalId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (SubterminalOperationTable.ContainsKey(operationCode))
            {
                return SubterminalOperationTable[operationCode].Handle(terminal, subterminalId, subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }

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

    public abstract class OperationRequestRouter<TTerminal, TSubterminalId, TEndTerminalId, TSubject, TOperationCode>
    {
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubterminalId, TEndTerminalId, TSubject, TOperationCode>> EndTerminalOperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubterminalId, TEndTerminalId, TSubject, TOperationCode>>();
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubterminalId, TSubject, TOperationCode>> SubterminalOperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubterminalId, TSubject, TOperationCode>>();
        protected Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>> OperationTable { get; private set; } = new Dictionary<TOperationCode, OperationRequestHandler<TTerminal, TSubject, TOperationCode>>();

        public bool Route(TTerminal terminal, TSubterminalId subterminalId, TEndTerminalId endTerminalId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (EndTerminalOperationTable.ContainsKey(operationCode))
            {
                return EndTerminalOperationTable[operationCode].Handle(terminal, subterminalId, endTerminalId, subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }
        public bool Route(TTerminal terminal, TSubterminalId subterminalId, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (SubterminalOperationTable.ContainsKey(operationCode))
            {
                return SubterminalOperationTable[operationCode].Handle(terminal, subterminalId, subject, operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {typeof(TSubject)}OperationRequest:{operationCode} from {typeof(TSubject)}: {subject}";
                return false;
            }
        }

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
}
