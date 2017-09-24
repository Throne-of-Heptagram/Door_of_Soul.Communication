using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.TrinityServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.System
{
    public static class SystemOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceSystemOperationRequest(deviceId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SystemOperationRequest(operationCode, parameters);
        }
    }
}
