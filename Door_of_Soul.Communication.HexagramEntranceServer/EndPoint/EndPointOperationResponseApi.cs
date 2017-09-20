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
        public static void SendOperationResponse(TerminalEndPoint target, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
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

        public static void EndPointSystemOperationResponse(TerminalEndPoint terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointSystemOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)EndPointSystemOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)EndPointSystemOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)EndPointSystemOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.EndPointSystemOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void EndPointAnswerOperationResponse(TerminalEndPoint terminal, Core.Answer target, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointAnswerOperationResponseParameterCode.AnswerId, target.AnswerId },
                { (byte)EndPointAnswerOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)EndPointAnswerOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)EndPointAnswerOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)EndPointAnswerOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.EndPointAnswerOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void EndPointSoulOperationResponse(TerminalEndPoint terminal, Core.Soul target, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointSoulOperationResponseParameterCode.SoulId, target.SoulId },
                { (byte)EndPointSoulOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)EndPointSoulOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)EndPointSoulOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)EndPointSoulOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.EndPointSoulOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void EndPointAvatarOperationResponse(TerminalEndPoint terminal, Core.Avatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointAvatarOperationResponseParameterCode.AvatarId, target.AvatarId },
                { (byte)EndPointAvatarOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)EndPointAvatarOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)EndPointAvatarOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)EndPointAvatarOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.EndPointAvatarOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void EndPointWorldOperationResponse(TerminalEndPoint terminal, int worldId, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointWorldOperationResponseParameterCode.WorldId, worldId },
                { (byte)EndPointWorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)EndPointWorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)EndPointWorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)EndPointWorldOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.EndPointWorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void EndPointSceneOperationResponse(TerminalEndPoint terminal, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointSceneOperationResponseParameterCode.SceneId, sceneId },
                { (byte)EndPointSceneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)EndPointSceneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)EndPointSceneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)EndPointSceneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, EndPointOperationCode.EndPointSceneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
