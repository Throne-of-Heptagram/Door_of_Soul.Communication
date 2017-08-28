using Door_of_Soul.Communication.Protocol.Hexagram.Love;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Love
{
    public static class LoveOperationRequestApi
    {
        public static void SendOperationRequest(LoveOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            LoveCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
