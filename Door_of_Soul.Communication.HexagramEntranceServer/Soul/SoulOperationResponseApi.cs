using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Soul
{
    public static class SoulOperationResponseApi
    {
        public static void SendOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Soul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SoulOperationResponse(terminal, deviceId, target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
