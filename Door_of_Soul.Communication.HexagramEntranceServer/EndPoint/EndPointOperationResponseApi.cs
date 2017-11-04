using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint
{
    public static class EndPointOperationResponseApi
    {
        public static void SendOperationResponse(TerminalEndPoint terminal, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            terminal.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
        public static void DeviceSystemOperationResponse(TerminalEndPoint terminal, int deviceId, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceSystemOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)DeviceSystemOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)DeviceSystemOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)DeviceSystemOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)DeviceSystemOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.DeviceSystemOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void DeviceAnswerOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Answer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceAnswerOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)DeviceAnswerOperationResponseParameterCode.AnswerId, target.AnswerId },
                { (byte)DeviceAnswerOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)DeviceAnswerOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)DeviceAnswerOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)DeviceAnswerOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.DeviceAnswerOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void DeviceSoulOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Soul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceSoulOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)DeviceSoulOperationResponseParameterCode.SoulId, target.SoulId },
                { (byte)DeviceSoulOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)DeviceSoulOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)DeviceSoulOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)DeviceSoulOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.DeviceSoulOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void DeviceAvatarOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Avatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceAvatarOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)DeviceAvatarOperationResponseParameterCode.AvatarId, target.AvatarId },
                { (byte)DeviceAvatarOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)DeviceAvatarOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)DeviceAvatarOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)DeviceAvatarOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.DeviceAvatarOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void DeviceWorldOperationResponse(TerminalEndPoint terminal, int deviceId, int worldId, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceWorldOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)DeviceWorldOperationResponseParameterCode.WorldId, worldId },
                { (byte)DeviceWorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)DeviceWorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)DeviceWorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)DeviceWorldOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.DeviceWorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void DeviceSceneOperationResponse(TerminalEndPoint terminal, int deviceId, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceSceneOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)DeviceSceneOperationResponseParameterCode.SceneId, sceneId },
                { (byte)DeviceSceneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)DeviceSceneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)DeviceSceneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)DeviceSceneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.DeviceSceneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }

        public static void SystemOperationResponse(TerminalEndPoint terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SystemOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SystemOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.SystemOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void AnswerOperationResponse(TerminalEndPoint terminal, Core.Answer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationResponseParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AnswerOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AnswerOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.AnswerOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SoulOperationResponse(TerminalEndPoint terminal, Core.Soul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationResponseParameterCode.SoulId, target.SoulId },
                { (byte)SoulOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SoulOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SoulOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.SoulOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void AvatarOperationResponse(TerminalEndPoint terminal, Core.Avatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationResponseParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AvatarOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AvatarOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.AvatarOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void WorldOperationResponse(TerminalEndPoint terminal, int worldId, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationResponseParameterCode.WorldId, worldId },
                { (byte)WorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)WorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)WorldOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.WorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SceneOperationResponse(TerminalEndPoint terminal, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationResponseParameterCode.SceneId, sceneId },
                { (byte)SceneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SceneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SceneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.SceneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
