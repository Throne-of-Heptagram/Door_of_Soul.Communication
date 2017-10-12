using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EntranceCommunicationService<TTerminal, TSubject, TOperationCode, TInverseOperationCode>
    {
        public static EntranceCommunicationService<TTerminal, TSubject, TOperationCode, TInverseOperationCode> Instance { get; private set; } = new EntranceCommunicationService<TTerminal, TSubject, TOperationCode, TInverseOperationCode>();

        public bool HandlerInverseEvent()
        {

        }

        public bool HandleOperationRequest(TTerminal hexagramEntrance, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramOperationRequestRouter<TTerminal, TSubject, TOperationCode>.Instance.Route(hexagramEntrance, subject, operationCode, parameters, out errorMessage);
        }

        public bool HandleInverseOperationResponse(TTerminal hexagramEntrance, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramInverseOperationResponseRouter<TTerminal, TSubject, TOperationCode>.Instance.Route(hexagramEntrance, subject, operationCode, parameters, out errorMessage);
        }
    }
}
