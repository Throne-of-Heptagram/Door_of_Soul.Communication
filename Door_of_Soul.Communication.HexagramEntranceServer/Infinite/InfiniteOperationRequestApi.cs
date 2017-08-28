using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Infinite
{
    public static class InfiniteOperationRequestApi
    {
        public static void SendOperationRequest(InfiniteOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            InfiniteCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
