using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public static class SpaceForwardOperationApi
    {
        public static void SendOperationRequest(SpaceForwardOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.SpaceOperationRequest(operationCode, parameters);
        }
    }
}
