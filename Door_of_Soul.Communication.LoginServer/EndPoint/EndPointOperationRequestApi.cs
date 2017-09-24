using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.EndPoint
{
    public static class EndPointOperationRequestApi
    {
        public static void SendOperationRequest(EndPointOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperation(operationCode, parameters);
        }
        public static void DeviceSystemOperationRequest(int devicdId, SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceSystemOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)DeviceSystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceSystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.DeviceSystemOperation, operationRequestParameters);
        }
        
        public static void SystemOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.SystemOperation, operationRequestParameters);
        }
    }
}
