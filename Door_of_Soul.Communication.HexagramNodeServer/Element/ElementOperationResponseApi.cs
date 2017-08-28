using Door_of_Soul.Communication.Protocol.Hexagram.Element;
//using Door_of_Soul.Communication.Protocol.Hexagram.Element.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Element
{
    public static class ElementOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, ElementOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<ElementEventCode, ElementOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
