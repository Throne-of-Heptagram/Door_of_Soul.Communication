using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public static class LoveOperationRequestApi
    {
        public static void SendOperationRequest(LoveOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.LoveOperationRequest(operationCode, parameters);
        }
    }
}
