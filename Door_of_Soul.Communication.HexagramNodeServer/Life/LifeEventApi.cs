﻿using System.Collections.Generic;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public static class LifeEventApi
    {
        public static void SendEvent(LifeHexagramEntrance target, LifeEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }
    }
}
