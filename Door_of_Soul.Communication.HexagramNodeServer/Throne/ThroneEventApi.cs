using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EventParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneEventApi
    {
        public static void SendEvent(ThroneHexagramEntrance terminal, ThroneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            terminal.SendEvent(eventCode, parameters);
        }

        public static void EndPointEvent(ThroneHexagramEntrance terminal, int endPointId, EndPointThroneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointThroneEventParameterCode.EndPointId, endPointId },
                { (byte)EndPointThroneEventParameterCode.EventCode, eventCode },
                { (byte)EndPointThroneEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, ThroneEventCode.EndPointThroneEvent, eventParameters);
        }
        public static void DeviceEvent(ThroneHexagramEntrance terminal, int endPointId, int deviceId, DeviceThroneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceThroneEventParameterCode.EndPointId, endPointId },
                { (byte)DeviceThroneEventParameterCode.DeviceId, deviceId },
                { (byte)DeviceThroneEventParameterCode.EventCode, eventCode },
                { (byte)DeviceThroneEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, ThroneEventCode.DeviceThroneEvent, eventParameters);
        }
    }
}
