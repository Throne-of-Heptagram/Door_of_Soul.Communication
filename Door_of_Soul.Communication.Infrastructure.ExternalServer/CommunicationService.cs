using Door_of_Soul.Communication.Infrastructure.ExternalServer.Device;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer
{
    public abstract class CommunicationService
    {
        public static CommunicationService Instance { get; private set; }
        public static void Initial(CommunicationService instance)
        {
            Instance = instance;
        }

        public abstract List<Core.Device> GetAllDevices();
        public abstract bool FindWorld(int worldId, out Core.World world);


        protected bool HandleOperationRequest(Core.Device device, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            return DeviceOperationRequestRouter.Instance.Route(device, operationCode, parameters, out errorMessage);
        }

        public abstract void SendEvent(Core.Device target, DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public abstract void SendOperationResponse(Core.Device target, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);
    }
}
