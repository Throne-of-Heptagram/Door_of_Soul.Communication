﻿using Door_of_Soul.Communication.Protocol.Internal.Answer;
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
        public static void SendOperationResponse(TerminalEndPoint target, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
        public static void SystemOperationResponse(TerminalEndPoint terminal, int deviceId, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)SystemOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SystemOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SystemOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.SystemOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void AnswerOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Answer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)AnswerOperationResponseParameterCode.AnswerId, target.AnswerId },
                { (byte)AnswerOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AnswerOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AnswerOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.AnswerOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SoulOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Soul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)SoulOperationResponseParameterCode.SoulId, target.SoulId },
                { (byte)SoulOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SoulOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SoulOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.SoulOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void AvatarOperationResponse(TerminalEndPoint terminal, int deviceId, Core.Avatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)AvatarOperationResponseParameterCode.AvatarId, target.AvatarId },
                { (byte)AvatarOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AvatarOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AvatarOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.AvatarOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void WorldOperationResponse(TerminalEndPoint terminal, int deviceId, int worldId, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)WorldOperationResponseParameterCode.WorldId, worldId },
                { (byte)WorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)WorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)WorldOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.WorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SceneOperationResponse(TerminalEndPoint terminal, int deviceId, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationResponseParameterCode.DeviceId, deviceId },
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
