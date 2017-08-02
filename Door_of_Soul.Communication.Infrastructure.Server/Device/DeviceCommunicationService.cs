namespace Door_of_Soul.Communication.Infrastructure.Server.Device
{
    public class DeviceCommunicationService
    {
        public DeviceCommunicationInterface CommunicationInterface { get; private set; }
        public DeviceOperationService OperationService { get; private set; }

        public DeviceCommunicationService(Core.Device device, DeviceCommunicationInterface communicationInterface)
        {
            CommunicationInterface = communicationInterface;
            OperationService = new DeviceOperationService(device, CommunicationInterface.SendOperationResponse);
        }
    }
}
