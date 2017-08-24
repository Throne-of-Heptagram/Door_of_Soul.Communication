using Door_of_Soul.Communication.ProxyServer.Device.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.External.Device;

namespace Door_of_Soul.Communication.ProxyServer.Device
{
    class DeviceOperationRequestRouter : OperationRequestRouter<TerminalDevice, TerminalDevice, DeviceOperationCode>
    {
        public static DeviceOperationRequestRouter Instance { get; private set; } = new DeviceOperationRequestRouter();

        private DeviceOperationRequestRouter()
        {
            OperationTable.Add(DeviceOperationCode.SystemOperation, new SystemOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.AnswerOperation, new AnswerOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.SoulOperation, new SoulOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.AvatarOperation, new AvatarOperationRequestBroker());
        }
    }
}
