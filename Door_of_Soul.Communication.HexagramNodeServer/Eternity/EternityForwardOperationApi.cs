using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Eternity
{
    public static class EternityForwardOperationApi
    {
        public static void SendOperationRequest(EternityForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.EternityOperationRequest(operationCode, parameters);
        }
    }
}
