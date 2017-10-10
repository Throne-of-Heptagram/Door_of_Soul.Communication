using Door_of_Soul.Communication.LoginServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System
{
    public static class SystemOperationRequestApi
    {
        public static void SendDeviceOperationRequest(int deviceId, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.DeviceSystemOperationRequest(deviceId, operationCode, parameters);
        }
        public static void SendEndPointOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointOperationRequestApi.SystemOperationRequest(operationCode, parameters);
        }

        public static void DeviceRegister(int deviceId, string answerName, string basicPassword)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceRegisterRequestParameterCode.AnswerName, answerName },
                { (byte)DeviceRegisterRequestParameterCode.BasicPassword, basicPassword }
            };
            SendDeviceOperationRequest(deviceId, SystemOperationCode.DeviceRegister, operationRequestParameters);
        }

        public static void GetAnswerTrinityServer(int answerId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetAnswerTrinityServerRequestParameterCode.AnswerId, answerId }
            };
            SendEndPointOperationRequest(SystemOperationCode.GetAnswerTrinityServer, operationRequestParameters);
        }
    }
}
