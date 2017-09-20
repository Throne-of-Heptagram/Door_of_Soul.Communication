using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.SceneServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.System
{
    public static class SystemOperationRequestApi
    {
        public static void SendEndPointOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.EndPointSystemOperationRequest(operationCode, parameters);
        }
    }
}
