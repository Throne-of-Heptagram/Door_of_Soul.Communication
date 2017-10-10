using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EntranceCommunicationService<TEventCode, TOperationCode, TSubject>
    {
        public static EntranceCommunicationService<TEventCode, TOperationCode, TSubject> Instance { get; private set; } = new EntranceCommunicationService<TEventCode, TOperationCode, TSubject>();

        public bool HandleOperationRequest(TerminalHexagramEntrance<TEventCode, TOperationCode> hexagramEntrance, TSubject subject, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramOperationRequestRouter<TEventCode, TOperationCode, TSubject>.Instance.Route(hexagramEntrance, subject, operationCode, parameters, out errorMessage);
        }
    }
}
