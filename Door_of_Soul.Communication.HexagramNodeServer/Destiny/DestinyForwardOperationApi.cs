using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Destiny
{
    public static class DestinyForwardOperationApi
    {
        public static void SendOperationRequest(DestinyForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.DestinyOperationRequest(operationCode, parameters);
        }
    }
}
