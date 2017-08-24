using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.System
{
    public static class SystemEventApi
    {
        public static void SendEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.SystemEvent(eventCode, parameters);
        }
    }
}
