using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Element
{
    public static class ElementForwardOperationApi
    {
        public static void SendOperationRequest(ElementForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramForwardOperationRequestApi.ElementOperationRequest(operationCode, parameters);
        }
    }
}
