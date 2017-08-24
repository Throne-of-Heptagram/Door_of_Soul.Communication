using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.Device
{
    public static class DeviceOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
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
        public static void WorldOperationResponse(TerminalDevice terminal, Core.World target, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationResponseParameterCode.WorldId, target.WorldId },
                { (byte)WorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)WorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)WorldOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.WorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SceneOperationResponse(TerminalDevice terminal, Core.Scene target, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationResponseParameterCode.SceneId, target.SceneId },
                { (byte)SceneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SceneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SceneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, DeviceOperationCode.SceneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
