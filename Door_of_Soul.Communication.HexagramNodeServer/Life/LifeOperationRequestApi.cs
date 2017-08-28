using Door_of_Soul.Communication.HexagramNodeServer.Hexagram;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public static class LifeOperationRequestApi
    {
        public static void SendOperationRequest(LifeOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            HexagramOperationRequestApi.LifeOperationRequest(operationCode, parameters);
        }
    }
}
