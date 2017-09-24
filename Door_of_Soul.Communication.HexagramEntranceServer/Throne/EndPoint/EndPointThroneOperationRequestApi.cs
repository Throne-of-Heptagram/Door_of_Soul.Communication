using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.EndPoint
{
    public static class EndPointThroneOperationRequestApi
    {
        public static void SendOperationRequest(int endPointId, EndPointThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            ThroneOperationRequestApi.SendEndPointOperationRequest(endPointId, operationCode, parameters);
        }
    }
}
