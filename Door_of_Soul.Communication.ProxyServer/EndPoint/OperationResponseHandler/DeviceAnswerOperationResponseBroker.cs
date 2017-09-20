using Door_of_Soul.Communication.ProxyServer.Answer;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint.OperationResponseHandler
{
    class DeviceAnswerOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public DeviceAnswerOperationResponseBroker() : base(typeof(DeviceAnswerOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if(base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)DeviceAnswerOperationResponseParameterCode.DeviceId];
                int answerId = (int)parameters[(byte)DeviceAnswerOperationResponseParameterCode.AnswerId];
                AnswerOperationCode resolvedOperationCode = (AnswerOperationCode)parameters[(byte)DeviceAnswerOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)DeviceAnswerOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)DeviceAnswerOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceAnswerOperationResponseParameterCode.Parameters];
                TerminalDevice device;
                if (DeviceFactory.Instance.Find(deviceId, out device))
                {
                    AnswerOperationResponseApi.SendOperationResponse(device, answerId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters);
                    return true;
                }
                else
                {
                    errorMessage = $"Can not find DeviceId:{deviceId}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
