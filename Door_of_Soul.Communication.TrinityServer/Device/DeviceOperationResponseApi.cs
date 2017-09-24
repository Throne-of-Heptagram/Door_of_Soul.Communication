using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Device
{
    public static class DeviceOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
        public static void SystemOperationResponse(TerminalDevice terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
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
        public static void AnswerOperationResponse(TerminalDevice terminal, int answerId, AnswerOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AnswerOperationResponseParameterCode.AnswerId, answerId },
                { (byte)AnswerOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AnswerOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AnswerOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AnswerOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.AnswerOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SoulOperationResponse(TerminalDevice terminal, int soulId, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SoulOperationResponseParameterCode.SoulId, soulId },
                { (byte)SoulOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SoulOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SoulOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SoulOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.SoulOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void AvatarOperationResponse(TerminalDevice terminal, int avatarId, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)AvatarOperationResponseParameterCode.AvatarId, avatarId },
                { (byte)AvatarOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)AvatarOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)AvatarOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)AvatarOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.AvatarOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
