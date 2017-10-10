using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public static class LifeForwardOperationApi
    {
        public static void SendOperationRequest(LifeForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramForwardOperationRequestApi.LifeOperationRequest(operationCode, parameters);
        }
    }
}
