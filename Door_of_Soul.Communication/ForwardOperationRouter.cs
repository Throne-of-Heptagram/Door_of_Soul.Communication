using System.Collections.Generic;

namespace Door_of_Soul.Communication
{
    public abstract class ForwardOperationRouter<TForwardOperationCode>
    {
        private string subjectName;
        protected Dictionary<TForwardOperationCode, ForwardOperationHandler<TForwardOperationCode>> OperationTable { get; private set; } = new Dictionary<TForwardOperationCode, ForwardOperationHandler<TForwardOperationCode>>();

        protected ForwardOperationRouter(string subjectName)
        {
            this.subjectName = subjectName;
        }

        public bool Route(TForwardOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (OperationTable.ContainsKey(operationCode))
            {
                return OperationTable[operationCode].Handle(operationCode, parameters, out errorMessage);
            }
            else
            {
                errorMessage = $"Unknow {subjectName}ForwardOperation ForwardOperationCode:{operationCode}";
                return false;
            }
        }
    }
}
