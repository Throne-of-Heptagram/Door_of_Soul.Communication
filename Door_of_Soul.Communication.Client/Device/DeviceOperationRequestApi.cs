using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device
{
    public static class DeviceOperationRequestApi
    {
        public static void SendProxyServerOperationRequest(DeviceOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendProxyServerOperation(operationCode, parameters);
        }
        public static void SendSceneServerOperationRequest(string sceneServerName, DeviceOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendSceneServerOperation(sceneServerName, operationCode, parameters);
        }
        public static void SystemOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendProxyServerOperationRequest(DeviceOperationCode.SystemOperation, operationRequestParameters);
        }
        public static void AnswerOperationRequest(int answerId, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationRequestParameterCode.AnswerId, answerId },
                { (byte)AnswerOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationRequestParameterCode.Parameters, parameters }
            };
            SendProxyServerOperationRequest(DeviceOperationCode.AnswerOperation, operationRequestParameters);
        }
        public static void SoulOperationRequest(int answerId, int soulId, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationRequestParameterCode.AnswerId, answerId },
                { (byte)SoulOperationRequestParameterCode.SoulId, soulId },
                { (byte)SoulOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationRequestParameterCode.Parameters, parameters }
            };
            SendProxyServerOperationRequest(DeviceOperationCode.SoulOperation, operationRequestParameters);
        }
        public static void AvatarOperationRequest(int answerId, int soulId, int avatarId, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationRequestParameterCode.AnswerId, answerId },
                { (byte)AvatarOperationRequestParameterCode.SoulId, soulId },
                { (byte)AvatarOperationRequestParameterCode.AvatarId, avatarId },
                { (byte)AvatarOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationRequestParameterCode.Parameters, parameters }
            };
            SendProxyServerOperationRequest(DeviceOperationCode.AvatarOperation, operationRequestParameters);
        }
        public static void WorldOperationRequest(string sceneServerName, int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationRequestParameterCode.WorldId, worldId },
                { (byte)WorldOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationRequestParameterCode.Parameters, parameters }
            };
            SendSceneServerOperationRequest(sceneServerName, DeviceOperationCode.WorldOperation, operationRequestParameters);
        }
        public static void SceneOperationRequest(string sceneServerName, int worldId, int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationRequestParameterCode.WorldId, worldId },
                { (byte)SceneOperationRequestParameterCode.SceneId, sceneId },
                { (byte)SceneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationRequestParameterCode.Parameters, parameters }
            };
            SendSceneServerOperationRequest(sceneServerName, DeviceOperationCode.SceneOperation, operationRequestParameters);
        }
    }
}
