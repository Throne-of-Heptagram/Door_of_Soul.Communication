using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationRequestParameter;
using Door_of_Soul.Communication.ProxyServer.EndPoint;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.System
{
    public static class SystemOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceSystemOperationRequest(deviceId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.EndPointSystemOperationRequest(operationCode, parameters);
        }

        public static void GetHexagramEntranceAnswer(int answerId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetHexagramEntranceAnswerRequestParameterCode.AnswerId, answerId },
            };
            SendEndPointOperationRequest(SystemOperationCode.GetHexagramEntranceAnswer, operationRequestParameters);
        }
    }
}
