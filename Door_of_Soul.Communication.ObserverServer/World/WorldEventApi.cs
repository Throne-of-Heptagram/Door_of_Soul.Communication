using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Communication.ObserverServer.Device;
using Door_of_Soul.Core.ObserverServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.World
{
    public static class WorldEventApi
    {
        public static void SendEvent(TerminalDevice terminal, VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.WorldEvent(terminal, target, eventCode, parameters);
        }

        public static void SendBroadcastEvent(VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            DeviceEventApi.BroadcastWorldEvent(target, eventCode, parameters);
        }
    }
}
