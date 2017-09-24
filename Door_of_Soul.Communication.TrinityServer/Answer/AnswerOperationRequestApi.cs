using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.TrinityServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Answer
{
    public static class AnswerOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, TerminalAnswer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceAnswerOperationRequest(deviceId, sender.AnswerId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(TerminalAnswer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.AnswerOperationRequest(sender.AnswerId, operationCode, parameters);
        }
    }
}
