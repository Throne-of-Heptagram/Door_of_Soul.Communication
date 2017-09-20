using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Answer.OperationRequestParameter;
using Door_of_Soul.Communication.ProxyServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Answer
{
    public static class AnswerOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, TerminalAnswer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceAnswerOperationRequest(deviceId, sender.AnswerId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(TerminalAnswer sender, AnswerOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.EndPointAnswerOperationRequest(sender.AnswerId, operationCode, parameters);
        }

        public static void GetHexagramEntranceSoul(TerminalAnswer sender, int soulId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetHexagramEntranceSoulRequestParameterCode.SoulId, soulId },
            };
            SendEndPointOperationRequest(sender, AnswerOperationCode.GetHexagramEntranceSoul, operationRequestParameters);
        }
    }
}
