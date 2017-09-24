using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.Device
{
    class DeviceThroneEventRouter : SubjectEventRouter<TerminalEndPoint, DeviceThroneEventCode>
    {
        public static DeviceThroneEventRouter Instance { get; private set; } = new DeviceThroneEventRouter();

        private DeviceThroneEventRouter() : base("HexagramEntranceServerDeviceThrone")
        {

        }
    }
}
