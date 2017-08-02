using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Communication.Protocol.Device;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Server.Device
{
    public interface DeviceCommunicationInterface
    {
        void SendEvent(DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        void SendOperationResponse(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);
    }
}
