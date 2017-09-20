using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Shadow
{
    public static class ShadowForwardOperationApi
    {
        public static void SendOperationRequest(ShadowForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.ShadowOperationRequest(operationCode, parameters);
        }
    }
}
