using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Device
{
    public static class DeviceEventApi
    {
        public static void SendEvent(TerminalDevice target, DeviceEventCode eventCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendEvent(target, eventCode, parameters);
        }
        public static void SystemEvent(SystemEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SystemEventParameterCode.EventCode, eventCode },
                { (byte)SystemEventParameterCode.Parameters, parameters }
            };
            foreach(var device in CommunicationService.Instance.GetAllDevices())
            {
                SendEvent(device, DeviceEventCode.SystemEvent, eventParameters);
            }
        }
        public static void AnswerEvent(TerminalAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerEventParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerEventParameterCode.EventCode, eventCode },
                { (byte)AnswerEventParameterCode.Parameters, parameters }
            };
            foreach(var device in target.Devices)
            {
                SendEvent(device, DeviceEventCode.AnswerEvent, eventParameters);
            }
        }
        public static void SoulEvent(Core.Soul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SoulEventParameterCode.SoulId, target.SoulId },
                { (byte)SoulEventParameterCode.EventCode, eventCode },
                { (byte)SoulEventParameterCode.Parameters, parameters }
            };
            foreach(var device in (target.Answer as TerminalAnswer).Devices)
            {
                SendEvent(device, DeviceEventCode.SoulEvent, eventParameters);
            }
        }
        public static void AvatarEvent(Core.Avatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarEventParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarEventParameterCode.EventCode, eventCode },
                { (byte)AvatarEventParameterCode.Parameters, parameters }
            };
            HashSet<TerminalDevice> deviceSet = new HashSet<TerminalDevice>();
            foreach(var soul in target.Souls)
            {
                foreach(var device in (soul.Answer as TerminalAnswer).Devices)
                {
                    deviceSet.Add(device);
                }
            }
            foreach (var device in deviceSet)
            {
                SendEvent(device, DeviceEventCode.AvatarEvent, eventParameters);
            }
        }
    }
}
