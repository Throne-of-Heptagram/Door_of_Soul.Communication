using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System
{
    public static class SystemOperationResponseApi
    {
        public static void SendOperationResponse(TerminalEndPoint terminal, int deviceId, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SystemOperationResponse(terminal, deviceId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
