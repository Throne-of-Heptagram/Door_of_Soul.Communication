using Door_of_Soul.Communication.Protocol.Hexagram.Element;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Element
{
    public static class ElementOperationRequestApi
    {
        public static void SendOperationRequest(ElementOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            ElementCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
