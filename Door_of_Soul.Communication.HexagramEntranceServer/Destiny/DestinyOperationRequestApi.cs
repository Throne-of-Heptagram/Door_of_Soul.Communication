using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Destiny
{
    public static class DestinyOperationRequestApi
    {
        public static void SendOperationRequest(DestinyOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DestinyCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
