using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Eternity
{
    public static class EternityOperationRequestApi
    {
        public static void SendOperationRequest(EternityOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EternityCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
