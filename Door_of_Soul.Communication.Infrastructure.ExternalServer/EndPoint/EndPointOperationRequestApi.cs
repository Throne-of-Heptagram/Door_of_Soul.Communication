using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint
{
    public static class EndPointOperationRequestApi
    {
        public static void SendOperationRequest(EndPointOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperation(operationCode, parameters);
        }
        public static void SystemOperationRequest(int devicdId, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)SystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.SystemOperation, operationRequestParameters);
        }
        public static void AnswerOperationRequest(int devicdId, int answerId, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)AnswerOperationRequestParameterCode.AnswerId, answerId },
                { (byte)AnswerOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.AnswerOperation, operationRequestParameters);
        }
        public static void SoulOperationRequest(int devicdId, int soulId, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)SoulOperationRequestParameterCode.SoulId, soulId },
                { (byte)SoulOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.SoulOperation, operationRequestParameters);
        }
        public static void AvatarOperationRequest(int devicdId, int avatarId, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)AvatarOperationRequestParameterCode.AvatarId, avatarId },
                { (byte)AvatarOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.AvatarOperation, operationRequestParameters);
        }
        public static void WorldOperationRequest(int devicdId, int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)WorldOperationRequestParameterCode.WorldId, worldId },
                { (byte)WorldOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.WorldOperation, operationRequestParameters);
        }
        public static void SceneOperationRequest(int devicdId, int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)SceneOperationRequestParameterCode.SceneId, sceneId },
                { (byte)SceneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.SceneOperation, operationRequestParameters);
        }
    }
}
