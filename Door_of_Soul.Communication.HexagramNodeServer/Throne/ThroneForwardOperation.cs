using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneForwardOperation
    {
        public static void SendOperationRequest(ThroneForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramForwardOperationRequestApi.ThroneOperationRequest(operationCode, parameters);
        }
    }
}
