using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    public static class InfiniteForwardOperationApi
    {
        public static void SendOperationRequest(InfiniteForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.InfiniteOperationRequest(operationCode, parameters);
        }
    }
}
