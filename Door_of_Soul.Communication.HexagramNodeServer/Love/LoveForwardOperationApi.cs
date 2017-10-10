using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public static class LoveForwardOperationApi
    {
        public static void SendOperationRequest(LoveForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramForwardOperationRequestApi.LoveOperationRequest(operationCode, parameters);
        }
    }
}
