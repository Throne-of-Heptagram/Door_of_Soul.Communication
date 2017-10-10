using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Eternity
{
    public static class EternityForwardOperationApi
    {
        public static void SendOperationRequest(EternityForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramForwardOperationRequestApi.EternityOperationRequest(operationCode, parameters);
        }
    }
}
