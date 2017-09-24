using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.Device
{
    public static class DeviceThroneEventApi
    {
        public static void SendEvent(ThroneHexagramEntrance terminal, int endPointId, int deviceId, DeviceThroneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            ThroneEventApi.DeviceEvent(terminal, endPointId, deviceId, eventCode, parameters);
        }
    }
}
