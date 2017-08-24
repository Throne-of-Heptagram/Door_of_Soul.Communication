using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.System
{
    public static class SystemOperationResponseApi
    {
        public static void SendOperationResponse(Core.Internal.EndPoint terminal, int deviceId, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SystemOperationResponse(terminal, deviceId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
