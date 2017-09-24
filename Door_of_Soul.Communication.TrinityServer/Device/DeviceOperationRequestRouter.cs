using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.TrinityServer.Device.OperationRequestHandler;

namespace Door_of_Soul.Communication.TrinityServer.Device
{
    class DeviceOperationRequestRouter : OperationRequestRouter<TerminalDevice, DeviceOperationCode>
    {
        public static DeviceOperationRequestRouter Instance { get; private set; } = new DeviceOperationRequestRouter();

        private DeviceOperationRequestRouter() : base("Device")
        {
            OperationTable.Add(DeviceOperationCode.SystemOperation, new SystemOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.AnswerOperation, new AnswerOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.SoulOperation, new SoulOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.AvatarOperation, new AvatarOperationRequestBroker());
        }
    }
}
