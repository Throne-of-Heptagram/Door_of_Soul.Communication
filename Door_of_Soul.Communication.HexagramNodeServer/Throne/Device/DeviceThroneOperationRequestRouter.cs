using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Communication.HexagramNodeServer.Throne.Device.OperationRequestHandler;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.Device
{
    public class DeviceThroneOperationRequestRouter : L3SubjectOperationRequestRouter<ThroneHexagramEntrance, int, int, VirtualThrone, DeviceThroneOperationCode>
    {
        public static DeviceThroneOperationRequestRouter Instance { get; private set; } = new DeviceThroneOperationRequestRouter();

        private DeviceThroneOperationRequestRouter() : base("HexagramEntranceServerDeviceThrone")
        {
            L3OperationTable.Add(DeviceThroneOperationCode.Register, new RegisterRequestHandler());
        }
    }
}
