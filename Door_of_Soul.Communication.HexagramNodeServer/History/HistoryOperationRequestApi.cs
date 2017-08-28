using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.History;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.History
{
    public static class HistoryOperationRequestApi
    {
        public static void SendOperationRequest(HistoryOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.HistoryOperationRequest(operationCode, parameters);
        }
    }
}
