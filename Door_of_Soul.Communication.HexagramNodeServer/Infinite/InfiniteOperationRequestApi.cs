using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    public static class InfiniteOperationRequestApi
    {
        public static void SendOperationRequest(InfiniteOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.InfiniteOperationRequest(operationCode, parameters);
        }
    }
}
