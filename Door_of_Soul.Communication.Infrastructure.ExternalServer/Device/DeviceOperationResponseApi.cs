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
        public static void SendOperationResponse(Core.External.Device target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
        public static void SystemOperationResponse(Core.External.Device terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SystemOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SystemOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.SystemOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void AnswerOperationResponse(Core.External.Device terminal, Core.External.ExternalAnswer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationResponseParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AnswerOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AnswerOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.AnswerOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SoulOperationResponse(Core.External.Device terminal, Core.Soul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationResponseParameterCode.SoulId, target.SoulId },
                { (byte)SoulOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SoulOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SoulOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.SoulOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void AvatarOperationResponse(Core.External.Device terminal, Core.Avatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationResponseParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AvatarOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AvatarOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.AvatarOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void WorldOperationResponse(Core.External.Device terminal, Core.World target, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationResponseParameterCode.WorldId, target.WorldId },
                { (byte)WorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)WorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)WorldOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.WorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SceneOperationResponse(Core.External.Device terminal, Core.Scene target, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationResponseParameterCode.SceneId, target.SceneId },
                { (byte)SceneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SceneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SceneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.SceneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
