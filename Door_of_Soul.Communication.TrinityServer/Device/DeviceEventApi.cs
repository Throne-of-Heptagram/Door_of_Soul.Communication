using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Device
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
        public static void AnswerEvent(TerminalDevice terminal, TerminalAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerEventParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerEventParameterCode.EventCode, eventCode },
                { (byte)AnswerEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, DeviceEventCode.AnswerEvent, eventParameters);
        }
        public static void SoulEvent(TerminalDevice terminal, VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SoulEventParameterCode.SoulId, target.SoulId },
                { (byte)SoulEventParameterCode.EventCode, eventCode },
                { (byte)SoulEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, DeviceEventCode.SoulEvent, eventParameters);
        }
        public static void AvatarEvent(TerminalDevice terminal, VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarEventParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarEventParameterCode.EventCode, eventCode },
                { (byte)AvatarEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, DeviceEventCode.AvatarEvent, eventParameters);
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
        public static void BroadcastAnswerEvent(TerminalAnswer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
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
        public static void BroadcastSoulEvent(VirtualSoul target, SoulEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SoulEventParameterCode.SoulId, target.SoulId },
                { (byte)SoulEventParameterCode.EventCode, eventCode },
                { (byte)SoulEventParameterCode.Parameters, parameters }
            };
            TerminalAnswer answer;
            if(ResourceService.Instance.FindAnswer(target.AnswerId, out answer))
            {
                foreach (var device in answer.Devices)
                {
                    SendEvent(device, DeviceEventCode.SoulEvent, eventParameters);
                }
            }
        }
        public static void BroadcastAvatarEvent(VirtualAvatar target, AvatarEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarEventParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarEventParameterCode.EventCode, eventCode },
                { (byte)AvatarEventParameterCode.Parameters, parameters }
            };
            HashSet<TerminalDevice> deviceSet = new HashSet<TerminalDevice>();
            foreach (var soulId in target.SoulIds)
            {
                VirtualSoul soul;
                if(ResourceService.Instance.FindSoul(soulId, out soul))
                {
                    TerminalAnswer answer;
                    if(ResourceService.Instance.FindAnswer(soul.AnswerId, out answer))
                    {
                        foreach (var device in answer.Devices)
                        {
                            deviceSet.Add(device);
                        }
                    }
                }
            }
            foreach (var device in deviceSet)
            {
                SendEvent(device, DeviceEventCode.AvatarEvent, eventParameters);
            }
        }
    }
}
