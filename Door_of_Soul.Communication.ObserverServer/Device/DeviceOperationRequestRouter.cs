using Door_of_Soul.Communication.ObserverServer.Device.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.External.Device;

namespace Door_of_Soul.Communication.ObserverServer.Device
{
    class DeviceOperationRequestRouter : BasicOperationRequestRouter<TerminalDevice, DeviceOperationCode>
    {
        public static DeviceOperationRequestRouter Instance { get; private set; } = new DeviceOperationRequestRouter();

        private DeviceOperationRequestRouter() : base("Device")
        {
            OperationTable.Add(DeviceOperationCode.WorldOperation, new WorldOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.SceneOperation, new SceneOperationRequestBroker());
        }
    }
}
