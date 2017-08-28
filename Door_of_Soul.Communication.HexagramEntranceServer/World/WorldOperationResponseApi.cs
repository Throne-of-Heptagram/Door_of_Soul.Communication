using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.World
{
    public static class WorldOperationResponseApi
    {
        public static void SendOperationResponse(TerminalEndPoint terminal, int deviceId, int worldId, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.WorldOperationResponse(terminal, deviceId, worldId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
