using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.History;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.History
{
    public static class HistoryForwardOperationApi
    {
        public static void SendOperationRequest(HistoryForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.HistoryOperationRequest(operationCode, parameters);
        }
    }
}
