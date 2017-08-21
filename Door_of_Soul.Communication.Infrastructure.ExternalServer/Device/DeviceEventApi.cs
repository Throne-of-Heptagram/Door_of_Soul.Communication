using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device
{
    public static class DeviceEventApi
    {
        public static void SendEvent(Core.Device target, DeviceEventCode eventCode, Dictionary<byte, object> parameters)
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
        public static void AnswerEvent(Core.Answer target, AnswerEventCode eventCode, Dictionary<byte, object> parameters)
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
            foreach(var device in target.Answer.Devices)
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
            HashSet<Core.Device> deviceSet = new HashSet<Core.Device>();
            foreach(var soul in target.Souls)
            {
                foreach(var device in soul.Answer.Devices)
                {
                    deviceSet.Add(device);
                }
            }
            foreach (var device in deviceSet)
            {
                SendEvent(device, DeviceEventCode.AvatarEvent, eventParameters);
            }
        }
        public static void WorldEvent(Core.World target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)WorldEventParameterCode.WorldId, target.WorldId },
                { (byte)WorldEventParameterCode.EventCode, eventCode },
                { (byte)WorldEventParameterCode.Parameters, parameters }
            };
            HashSet<Core.Device> deviceSet = new HashSet<Core.Device>();
            foreach(var scene in target.Scenes)
            {
                foreach (var avatar in scene.Avatars)
                {
                    foreach (var soul in avatar.Souls)
                    {
                        foreach (var device in soul.Answer.Devices)
                        {
                            deviceSet.Add(device);
                        }
                    }
                }
            }
            foreach (var device in deviceSet)
            {
                SendEvent(device, DeviceEventCode.WorldEvent, eventParameters);
            }
        }
        public static void SceneEvent(Core.Scene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SceneEventParameterCode.SceneId, target.SceneId },
                { (byte)SceneEventParameterCode.EventCode, eventCode },
                { (byte)SceneEventParameterCode.Parameters, parameters }
            };
            HashSet<Core.Device> deviceSet = new HashSet<Core.Device>();
            foreach (var avatar in target.Avatars)
            {
                foreach (var soul in avatar.Souls)
                {
                    foreach (var device in soul.Answer.Devices)
                    {
                        deviceSet.Add(device);
                    }
                }
            }
            foreach (var device in deviceSet)
            {
                SendEvent(device, DeviceEventCode.SceneEvent, eventParameters);
            }
        }
    }
}
