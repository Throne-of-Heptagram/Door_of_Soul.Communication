﻿using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.Soul
{
    public static class SoulEventApi
    {
        public static void SendEvent(Core.Soul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            EndPointEventApi.SoulEvent(target, eventCode, parameters);
        }
    }
}
