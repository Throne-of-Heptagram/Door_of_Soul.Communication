using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.Device
{
    public static class DeviceEventApi
    {
        public static void SendEvent(TerminalDevice target, DeviceEventCode eventCode, Dictionary<byte, object> parameters)
        {
            target.SendEvent(eventCode, parameters);
        }

        public static void SystemEvent(TerminalDevice terminal, SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SystemEventParameterCode.EventCode, eventCode },
                { (byte)SystemEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, DeviceEventCode.SystemEvent, eventParameters);
        }
        
        public static void BroadcastSystemEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SystemEventParameterCode.EventCode, eventCode },
                { (byte)SystemEventParameterCode.Parameters, parameters }
            };
            foreach(var device in DeviceFactory.Instance.Subjects)
            {
                SendEvent(device, DeviceEventCode.SystemEvent, eventParameters);
            }
        }
    }
}
