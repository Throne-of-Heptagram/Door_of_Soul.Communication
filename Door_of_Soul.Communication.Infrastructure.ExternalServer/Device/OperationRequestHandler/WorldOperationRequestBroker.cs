using Door_of_Soul.Communication.Infrastructure.ExternalServer.World;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device.OperationRequestHandler
{
    class WorldOperationRequestBroker : OperationRequestHandler<Core.Device, DeviceOperationCode>
    {
        public WorldOperationRequestBroker() : base(typeof(WorldOperationRequestParameterCode))
        {
        }

        public override void SendResponse(Core.Device target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(Core.Device requester, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(requester, operationCode, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)WorldOperationRequestParameterCode.WorldId];
                string authenticationToken = (string)parameters[(byte)WorldOperationRequestParameterCode.AuthenticationToken];
                WorldOperationCode worldOperationCode = (WorldOperationCode)parameters[(byte)WorldOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)WorldOperationRequestParameterCode.Parameters];
                Core.World world;
                if (CommunicationService.Instance.FindWorld(worldId, out world) && CommunicationService.Instance.WorldAuthenticate(authenticationToken))
                {
                    return WorldOperationRequestRouter.Instance.Route(world, worldOperationCode, operationRequestParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find WorldId:{worldId}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
