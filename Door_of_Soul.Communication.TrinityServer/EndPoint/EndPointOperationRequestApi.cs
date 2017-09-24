using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint
{
    public static class EndPointOperationRequestApi
    {
        public static void SendOperationRequest(EndPointOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperation(operationCode, parameters);
        }
        public static void DeviceSystemOperationRequest(int devicdId, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceSystemOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)DeviceSystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceSystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.DeviceSystemOperation, operationRequestParameters);
        }
        public static void DeviceAnswerOperationRequest(int devicdId, int answerId, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceAnswerOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)DeviceAnswerOperationRequestParameterCode.AnswerId, answerId },
                { (byte)DeviceAnswerOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceAnswerOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.DeviceAnswerOperation, operationRequestParameters);
        }
        public static void DeviceSoulOperationRequest(int devicdId, int soulId, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceSoulOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)DeviceSoulOperationRequestParameterCode.SoulId, soulId },
                { (byte)DeviceSoulOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceSoulOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.DeviceSoulOperation, operationRequestParameters);
        }
        public static void DeviceAvatarOperationRequest(int devicdId, int avatarId, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceAvatarOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)DeviceAvatarOperationRequestParameterCode.AvatarId, avatarId },
                { (byte)DeviceAvatarOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceAvatarOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.DeviceAvatarOperation, operationRequestParameters);
        }
        public static void SystemOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.SystemOperation, operationRequestParameters);
        }
        public static void AnswerOperationRequest(int answerId, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationRequestParameterCode.AnswerId, answerId },
                { (byte)AnswerOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.AnswerOperation, operationRequestParameters);
        }
        public static void SoulOperationRequest(int soulId, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationRequestParameterCode.SoulId, soulId },
                { (byte)SoulOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.SoulOperation, operationRequestParameters);
        }
        public static void AvatarOperationRequest(int avatarId, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationRequestParameterCode.AvatarId, avatarId },
                { (byte)AvatarOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.AvatarOperation, operationRequestParameters);
        }
    }
}
