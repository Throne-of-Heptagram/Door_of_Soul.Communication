using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EntranceCommunicationService<TTerminal, TSubject, TOperationCode, TInverseEventCode, TInverseOperationCode>
    {
        public static EntranceCommunicationService<TTerminal, TSubject, TOperationCode, TInverseEventCode, TInverseOperationCode> Instance { get; private set; } = new EntranceCommunicationService<TTerminal, TSubject, TOperationCode, TInverseEventCode, TInverseOperationCode>();

        public OperationReturnCode HandleInverseEvent(TTerminal hexagramEntrance, TSubject subject, TInverseEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramInverseEventRouter<TTerminal, TSubject, TInverseEventCode>.Instance.Route(hexagramEntrance, subject, eventCode, parameters, out errorMessage);
        }

        public OperationReturnCode HandleOperationRequest(TTerminal hexagramEntrance, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramOperationRequestRouter<TTerminal, TSubject, TOperationCode>.Instance.Route(hexagramEntrance, subject, operationCode, parameters, out errorMessage);
        }

        public OperationReturnCode HandleInverseOperationResponse(TTerminal hexagramEntrance, TSubject subject, TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramInverseOperationResponseRouter<TTerminal, TSubject, TOperationCode>.Instance.Route(hexagramEntrance, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage);
        }
    }
}
