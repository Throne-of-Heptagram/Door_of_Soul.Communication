using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneOperationResponseApi
    {
        public static void SendOperationResponse(ThroneHexagramEntrance terminal, ThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            terminal.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void EndPointOperationResponse(ThroneHexagramEntrance terminal, int endPointId, EndPointThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointThroneOperationResponseParameterCode.EndPointId, endPointId },
                { (byte)EndPointThroneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)EndPointThroneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)EndPointThroneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)EndPointThroneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, ThroneOperationCode.EndPointThroneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void DeviceOperationResponse(ThroneHexagramEntrance terminal, int endPointId, int deviceId, DeviceThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceThroneOperationResponseParameterCode.EndPointId, endPointId },
                { (byte)DeviceThroneOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)DeviceThroneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)DeviceThroneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)DeviceThroneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)DeviceThroneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, ThroneOperationCode.DeviceThroneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }

        public static void GetAnswerTrinityServer(ThroneHexagramEntrance terminal, OperationReturnCode returnCode, string operationMessage, int trinityServerEndPointId, int answerId, string answerAccessToken)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetAnswerTrinityServerResponseParameterCode.TrinityServerEndPointId, trinityServerEndPointId },
                { (byte)GetAnswerTrinityServerResponseParameterCode.AnswerId, answerId },
                { (byte)GetAnswerTrinityServerResponseParameterCode.AnswerAccessToken, answerAccessToken }
            };
            SendOperationResponse(terminal, ThroneOperationCode.GetAnswerTrinityServer, returnCode, operationMessage, operationResponseParameters);
        }
    }
}
