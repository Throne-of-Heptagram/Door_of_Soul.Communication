using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public static class WillForwardOperationApi
    {
        public static void SendOperationRequest(WillForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.WillOperationRequest(operationCode, parameters);
        }
    }
}
