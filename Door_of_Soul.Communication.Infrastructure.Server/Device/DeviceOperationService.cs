using Door_of_Soul.Communication.Protocol.Device;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Server.Device
{
    public class DeviceOperationService
    {
        private Core.Device device;

        private Dictionary<DeviceOperationCode, OperationRequestHandler<Core.Device, DeviceOperationCode>> requestHandlerTable = new Dictionary<DeviceOperationCode, OperationRequestHandler<Core.Device, DeviceOperationCode>>();
        private OperationResponseSender<DeviceOperationCode> responseSender;

        public DeviceOperationService(Core.Device device, OperationResponseSender<DeviceOperationCode> responseSender)
        {
            this.device = device;
            this.responseSender = responseSender;
        }

        public bool Operate(DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (requestHandlerTable.ContainsKey(operationCode))
            {
                if (requestHandlerTable[operationCode].Handle(operationCode, parameters, out errorMessage))
                {
                    return true;
                }
                else
                {
                    errorMessage = $"DeviceOperationRequest: {operationCode}, Device: {device}, ErrorMessage: {errorMessage}";
                    return false;
                }
            }
            else
            {
                errorMessage = $"Unknow DeviceOperationRequest:{operationCode}, Device: {device}";
                return false;
            }
        }
    }
}
