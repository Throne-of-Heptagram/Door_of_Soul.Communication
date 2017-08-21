using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.System
{
    public static class SystemOperationResponseApi
    {
        public static void SendOperationResponse(SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SystemOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
