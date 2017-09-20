using Door_of_Soul.Communication.Client.Device;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.OperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.System
{
    public static class SystemOperationRequestApi
    {
        public static void SendOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.SystemOperationRequest(operationCode, parameters);
        }

        public static void Register(string answerName, string basicPassword)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)RegisterRequestParameterCode.AnswerName, answerName },
                { (byte)RegisterRequestParameterCode.BasicPassword, basicPassword }
            };
            SendOperationRequest(SystemOperationCode.Register, operationRequestParameters);
        }

        public static void Login(string answerName, string basicPassword)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)LoginRequestParameterCode.AnswerName, answerName },
                { (byte)LoginRequestParameterCode.BasicPassword, basicPassword }
            };
            SendOperationRequest(SystemOperationCode.Login, operationRequestParameters);
        }
    }
}
