using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    public static class ThroneOperationRequestApi
    {
        public static void SendOperationRequest(ThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            ThroneCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
