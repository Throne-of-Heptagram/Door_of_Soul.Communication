using Door_of_Soul.Communication.HexagramNodeServer.HexagramCentral;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public static class SpaceForwardOperationApi
    {
        public static void SendOperationRequest(SpaceForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramForwardOperationRequestApi.SpaceOperationRequest(operationCode, parameters);
        }
    }
}
