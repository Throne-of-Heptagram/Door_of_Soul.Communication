using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer
{
    public class TerminalDevice : IEventDependencyReleasable
    {
        public delegate void SendEventDelegate(DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public event Action OnEventDependencyDisappear;

        public int DeviceId { get; private set; }
        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }

        public TerminalDevice(int deviceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod)
        {
            DeviceId = deviceId;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
        }

        

        public override string ToString()
        {
            return $"Device Id:{DeviceId}";
        }

        public void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }
    }
}
