using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneOperationRequestApi
    {
        public static void SendOperationRequest(ThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.ThroneOperationRequest(operationCode, parameters);
        }
    }
}
