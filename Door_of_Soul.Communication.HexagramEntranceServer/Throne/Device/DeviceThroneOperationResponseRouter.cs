using Door_of_Soul.Communication.HexagramEntranceServer.Throne.Device.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.Device
{
    class DeviceThroneOperationResponseRouter : L2SubjectOperationResponseRouter<TerminalEndPoint, int, DeviceThroneOperationCode>
    {
        public static DeviceThroneOperationResponseRouter Instance { get; private set; } = new DeviceThroneOperationResponseRouter();

        private DeviceThroneOperationResponseRouter() : base("HexagramEntranceServerDeviceThrone")
        {
            OperationTable.Add(DeviceThroneOperationCode.Register, new RegisterResponseHandler());
        }
    }
}
