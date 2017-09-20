using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Soul;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint
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
        public static void EndPointSystemOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointSystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointSystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.EndPointSystemOperation, operationRequestParameters);
        }
        public static void EndPointAnswerOperationRequest(int answerId, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointAnswerOperationRequestParameterCode.AnswerId, answerId },
                { (byte)EndPointAnswerOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointAnswerOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.EndPointAnswerOperation, operationRequestParameters);
        }
        public static void EndPointSoulOperationRequest(int soulId, SoulOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointSoulOperationRequestParameterCode.SoulId, soulId },
                { (byte)EndPointSoulOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointSoulOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.EndPointSoulOperation, operationRequestParameters);
        }
        public static void EndPointAvatarOperationRequest(int avatarId, AvatarOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointAvatarOperationRequestParameterCode.AvatarId, avatarId },
                { (byte)EndPointAvatarOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointAvatarOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.EndPointAvatarOperation, operationRequestParameters);
        }
    }
}
