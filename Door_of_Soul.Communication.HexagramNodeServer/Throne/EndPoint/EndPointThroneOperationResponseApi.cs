using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.EndPoint
{
    public static class EndPointThroneOperationResponseApi
    {
        public static void SendOperationResponse(ThroneHexagramEntrance terminal, int endPointId, EndPointThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.EndPointOperationResponse(terminal, endPointId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
