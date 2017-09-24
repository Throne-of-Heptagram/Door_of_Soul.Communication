using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.Device
{
    public static class DeviceThroneOperationResponseApi
    {
        public static void SendOperationResponse(ThroneHexagramEntrance terminal, int endPointId, int deviceId, DeviceThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.DeviceOperationResponse(terminal, endPointId, deviceId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
