using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer
{
    public class TerminalDevice
    {
        public delegate void SendEventDelegate(DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public int DeviceId { get; private set; }
        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }

        public TerminalDevice(int deviceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod)
        {
            DeviceId = deviceId;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
        }
    }
}
