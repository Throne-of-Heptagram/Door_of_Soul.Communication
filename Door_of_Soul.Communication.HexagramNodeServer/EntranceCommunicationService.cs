using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EntranceCommunicationService<TEventCode, TOperationCode>
    {
        public static EntranceCommunicationService<TEventCode, TOperationCode> Instance { get; private set; } = new EntranceCommunicationService<TEventCode, TOperationCode>();

        public bool HandleOperationRequest(TerminalHexagramEntrance<TEventCode, TOperationCode> hexagramEntrance, TOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return HexagramOperationRequestRouter<TEventCode, TOperationCode>.Instance.Route(hexagramEntrance, operationCode, parameters, out errorMessage);
        }
    }
}
