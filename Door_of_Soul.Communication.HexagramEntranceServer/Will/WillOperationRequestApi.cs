using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Will
{
    public static class WillOperationRequestApi
    {
        public static void SendOperationRequest(WillOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            WillCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
