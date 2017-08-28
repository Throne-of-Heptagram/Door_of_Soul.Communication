using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public static class WillOperationRequestApi
    {
        public static void SendOperationRequest(WillOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.WillOperationRequest(operationCode, parameters);
        }
    }
}
