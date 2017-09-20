using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationResponseParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;
using System.Linq;

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
            EndPointOperationResponseApi.EndPointSystemOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void GetHexagramEntranceAnswer(TerminalEndPoint terminal, OperationReturnCode operationReturnCode, string operationMessage, VirtualAnswer answer)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)GetHexagramEntranceAnswerResponseParameterCode.AnswerId, answer.SoulIds },
                { (byte)GetHexagramEntranceAnswerResponseParameterCode.AnswerName, answer.AnswerName },
                { (byte)GetHexagramEntranceAnswerResponseParameterCode.SoulIds, answer.SoulIds.ToArray() }
            };
            SendEndPointOperationResponse(terminal, SystemOperationCode.GetHexagramEntranceAnswer, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
