using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.Device
{
    public static class DeviceOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
        public static void SystemOperationResponse(TerminalDevice terminal, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SystemOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SystemOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SystemOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SystemOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.SystemOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
