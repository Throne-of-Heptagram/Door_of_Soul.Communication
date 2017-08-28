using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Shadow
{
    public static class ShadowOperationRequestApi
    {
        public static void SendOperationRequest(ShadowOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            ShadowCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
