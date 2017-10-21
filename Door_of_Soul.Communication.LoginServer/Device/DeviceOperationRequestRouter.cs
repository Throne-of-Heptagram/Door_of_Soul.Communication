using Door_of_Soul.Communication.LoginServer.Device.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.External.Device;

namespace Door_of_Soul.Communication.LoginServer.Device
{
    class DeviceOperationRequestRouter : BasicOperationRequestRouter<TerminalDevice, DeviceOperationCode>
    {
        public static DeviceOperationRequestRouter Instance { get; private set; } = new DeviceOperationRequestRouter();

        private DeviceOperationRequestRouter() : base("Device")
        {
            OperationTable.Add(DeviceOperationCode.SystemOperation, new SystemOperationRequestBroker());
        }
    }
}
