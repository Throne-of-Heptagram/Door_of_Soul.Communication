using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device
{
    public static class DeviceOperationResponseApi
    {
        public static void SendOperationResponse(Core.Device target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
        public static void SystemOperationResponse(SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SystemOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SystemOperationResponseParameterCode.Parameters, parameters }
            };
            foreach (var device in CommunicationService.Instance.GetAllDevices())
            {
                SendOperationResponse(device, DeviceOperationCode.SystemOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
            }
        }
        public static void AnswerOperationResponse(Core.Answer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationResponseParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AnswerOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AnswerOperationResponseParameterCode.Parameters, parameters }
            };
            foreach (var device in target.Devices)
            {
                SendOperationResponse(device, DeviceOperationCode.AnswerOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
            }
        }
        public static void SoulOperationResponse(Core.Soul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationResponseParameterCode.SoulId, target.SoulId },
                { (byte)SoulOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SoulOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SoulOperationResponseParameterCode.Parameters, parameters }
            };
            foreach (var device in target.Answer.Devices)
            {
                SendOperationResponse(device, DeviceOperationCode.SoulOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
            }
        }
        public static void AvatarOperationResponse(Core.Avatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationResponseParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AvatarOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AvatarOperationResponseParameterCode.Parameters, parameters }
            };
            HashSet<Core.Device> deviceSet = new HashSet<Core.Device>();
            foreach (var soul in target.Souls)
            {
                foreach (var device in soul.Answer.Devices)
                {
                    deviceSet.Add(device);
                }
            }
            foreach (var device in deviceSet)
            {
                SendOperationResponse(device, DeviceOperationCode.AvatarOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
            }
        }
        public static void WorldOperationResponse(Core.World target, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationResponseParameterCode.WorldId, target.WorldId },
                { (byte)WorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)WorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)WorldOperationResponseParameterCode.Parameters, parameters }
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
                SendOperationResponse(device, DeviceOperationCode.WorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
            }
        }
        public static void SceneOperationResponse(Core.Scene target, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationResponseParameterCode.SceneId, target.SceneId },
                { (byte)SceneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SceneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SceneOperationResponseParameterCode.Parameters, parameters }
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
                SendOperationResponse(device, DeviceOperationCode.SceneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
            }
        }
    }
}
