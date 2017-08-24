using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.External.Device;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device
{
    class DeviceOperationRequestRouter : OperationRequestRouter<Core.External.Device, Core.External.Device, DeviceOperationCode>
    {
        public static DeviceOperationRequestRouter Instance { get; private set; } = new DeviceOperationRequestRouter();

        private DeviceOperationRequestRouter()
        {
            OperationTable.Add(DeviceOperationCode.SystemOperation, new SystemOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.AnswerOperation, new AnswerOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.SoulOperation, new SoulOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.AvatarOperation, new AvatarOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.WorldOperation, new WorldOperationRequestBroker());
            OperationTable.Add(DeviceOperationCode.SceneOperation, new SceneOperationRequestBroker());
        }
    }
}
