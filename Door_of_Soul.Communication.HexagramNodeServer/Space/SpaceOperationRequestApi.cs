using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public static class SpaceOperationRequestApi
    {
        public static void SendOperationRequest(SpaceOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.SpaceOperationRequest(operationCode, parameters);
        }
    }
}
