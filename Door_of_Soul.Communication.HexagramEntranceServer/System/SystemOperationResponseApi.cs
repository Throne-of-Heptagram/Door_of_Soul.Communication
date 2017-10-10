using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System
{
    public static class SystemOperationResponseApi
    {
        public static void SendDeviceOperationResponse(TerminalEndPoint terminal, int deviceId, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.DeviceSystemOperationResponse(terminal, deviceId, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void SendEndPointOperationResponse(TerminalEndPoint terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SystemOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void GetAnswerTrinityServer(TerminalEndPoint terminal, OperationReturnCode returnCode, string operationMessage, int trinityServerEndPointId, int answerId, string answerAccessToken)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetAnswerTrinityServerResponseParameterCode.TrinityServerEndPointId, trinityServerEndPointId },
                { (byte)GetAnswerTrinityServerResponseParameterCode.AnswerId, answerId },
                { (byte)GetAnswerTrinityServerResponseParameterCode.AnswerAccessToken, answerAccessToken }
            };
            SendEndPointOperationResponse(terminal, SystemOperationCode.GetAnswerTrinityServer, returnCode, operationMessage, operationResponseParameters);
        }
    }
}
