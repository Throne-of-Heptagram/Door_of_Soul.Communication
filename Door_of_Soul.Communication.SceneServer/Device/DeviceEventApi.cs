﻿using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.Device
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
        public static void WorldEvent(Core.World target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)WorldEventParameterCode.WorldId, target.WorldId },
                { (byte)WorldEventParameterCode.EventCode, eventCode },
                { (byte)WorldEventParameterCode.Parameters, parameters }
            };
            HashSet<TerminalDevice> deviceSet = new HashSet<TerminalDevice>();
            foreach(var scene in target.Scenes)
            {
                foreach (var device in (scene as TerminalScene).Devices)
                {
                    deviceSet.Add(device);
                }
            }
            foreach (var device in deviceSet)
            {
                SendEvent(device, DeviceEventCode.WorldEvent, eventParameters);
            }
        }
        public static void SceneEvent(TerminalScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SceneEventParameterCode.SceneId, target.SceneId },
                { (byte)SceneEventParameterCode.EventCode, eventCode },
                { (byte)SceneEventParameterCode.Parameters, parameters }
            };
            foreach (var device in target.Devices)
            {
                SendEvent(device, DeviceEventCode.SceneEvent, eventParameters);
            }
        }
    }
}