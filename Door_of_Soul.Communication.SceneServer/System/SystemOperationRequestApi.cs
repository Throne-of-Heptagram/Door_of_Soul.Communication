using Door_of_Soul.Communication.SceneServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.System
{
    public static class SystemOperationRequestApi
    {
        public static void SendOperationRequest(int deviceId, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SystemOperationRequest(deviceId, operationCode, parameters);
        }
    }
}
