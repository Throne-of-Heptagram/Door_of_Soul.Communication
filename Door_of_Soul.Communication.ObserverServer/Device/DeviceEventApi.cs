using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.ObserverServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.Device
{
    public static class DeviceEventApi
    {
        public static void SendEvent(TerminalDevice terminal, DeviceEventCode eventCode, Dictionary<byte, object> parameters)
        {
            terminal.SendEvent(eventCode, parameters);
        }

        public static void WorldEvent(TerminalDevice terminal, VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)WorldEventParameterCode.WorldId, target.WorldId },
                { (byte)WorldEventParameterCode.EventCode, eventCode },
                { (byte)WorldEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, DeviceEventCode.WorldEvent, eventParameters);
        }
        public static void SceneEvent(TerminalDevice terminal, TerminalScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)SceneEventParameterCode.SceneId, target.SceneId },
                { (byte)SceneEventParameterCode.EventCode, eventCode },
                { (byte)SceneEventParameterCode.Parameters, parameters }
            };
            SendEvent(terminal, DeviceEventCode.SceneEvent, eventParameters);
        }

        public static void BroadcastWorldEvent(VirtualWorld target, WorldEventCode eventCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> eventParameters = new Dictionary<byte, object>
            {
                { (byte)WorldEventParameterCode.WorldId, target.WorldId },
                { (byte)WorldEventParameterCode.EventCode, eventCode },
                { (byte)WorldEventParameterCode.Parameters, parameters }
            };
            HashSet<TerminalDevice> deviceSet = new HashSet<TerminalDevice>();
            foreach (var sceneId in target.SceneIds)
            {
                TerminalScene scene;
                if(ResourceService.Instance.FindScene(sceneId, out scene))
                {
                    foreach (var device in scene.Devices)
                    {
                        deviceSet.Add(device);
                    }
                }
            }
            foreach (var device in deviceSet)
            {
                SendEvent(device, DeviceEventCode.WorldEvent, eventParameters);
            }
        }
        public static void BroadcastSceneEvent(TerminalScene target, SceneEventCode eventCode, Dictionary<byte, object> parameters)
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
