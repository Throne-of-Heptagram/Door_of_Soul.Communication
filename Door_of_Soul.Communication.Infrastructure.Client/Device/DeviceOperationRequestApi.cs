using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.World;
using System.Collections.Generic;
using System.Linq;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device
{
    public static class DeviceOperationRequestApi
    {
        public static void SendOperationRequest(DeviceOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperation(operationCode, parameters);
        }
        public static void SystemOperationRequest(string authenticationToken, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationRequestParameterCode.AuthenticationToken, authenticationToken },
                { (byte)SystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(DeviceOperationCode.SystemOperation, operationRequestParameters);
        }
        public static void AnswerOperationRequest(Core.Answer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationRequestParameterCode.AnswerId, sender.AnswerId },
                { (byte)AnswerOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(DeviceOperationCode.AnswerOperation, operationRequestParameters);
        }
        public static void SoulOperationRequest(Core.Soul sender, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (sender.Answer == null)
                return;
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationRequestParameterCode.AnswerId, sender.Answer.AnswerId },
                { (byte)SoulOperationRequestParameterCode.SoulId, sender.SoulId },
                { (byte)SoulOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(DeviceOperationCode.SoulOperation, operationRequestParameters);
        }
        public static void AvatarOperationRequest(Core.Avatar sender, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (!sender.Souls.Any())
                return;
            Core.Soul firstSoul = sender.Souls.First(x => x.Answer != null);
            if (firstSoul == null)
                return;
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationRequestParameterCode.AnswerId, firstSoul.Answer.AnswerId },
                { (byte)AvatarOperationRequestParameterCode.SoulId, firstSoul.SoulId },
                { (byte)AvatarOperationRequestParameterCode.AvatarId, sender.AvatarId },
                { (byte)AvatarOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(DeviceOperationCode.AvatarOperation, operationRequestParameters);
        }
        public static void WorldOperationRequest(Core.World sender, string authenticationToken, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationRequestParameterCode.WorldId, sender.WorldId },
                { (byte)WorldOperationRequestParameterCode.AuthenticationToken, authenticationToken },
                { (byte)WorldOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(DeviceOperationCode.WorldOperation, operationRequestParameters);
        }
        public static void SceneOperationRequest(Core.Scene sender, Core.Avatar observer, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            if (sender.BelongingWorld == null)
                return;
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationRequestParameterCode.WorldId, sender.BelongingWorld.WorldId },
                { (byte)SceneOperationRequestParameterCode.SceneId, sender.SceneId },
                { (byte)SceneOperationRequestParameterCode.ObserverAvatarId, observer.AvatarId },
                { (byte)SceneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(DeviceOperationCode.SceneOperation, operationRequestParameters);
        }
    }
}
