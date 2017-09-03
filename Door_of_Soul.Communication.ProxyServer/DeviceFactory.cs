using Door_of_Soul.Core;

namespace Door_of_Soul.Communication.ProxyServer
{
    public class DeviceFactory : GenericSubjectRepository<int, TerminalDevice>
    {
        public static DeviceFactory Instance { get; private set; } = new DeviceFactory();

        private int deviceCounter = 1;
        private object deviceCounterLock = new object();

        private DeviceFactory()
        {

        }

        public bool CreateDevice(TerminalDevice.SendEventDelegate sendEventMethod, TerminalDevice.SendOperationResponseDelegate sendOperationResponseMethod, out TerminalDevice device)
        {
            lock (deviceCounterLock)
            {
                device = new TerminalDevice(deviceCounter, sendEventMethod, sendOperationResponseMethod);
                deviceCounter++;
                return Add(device.DeviceId, device);
            }
        }
    }
}
