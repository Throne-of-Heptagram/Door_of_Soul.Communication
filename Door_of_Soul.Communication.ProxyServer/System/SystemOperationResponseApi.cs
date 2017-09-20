using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.System
{
    public static class SystemOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SystemOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
