using Door_of_Soul.Communication.Infrastructure.InternalServer.World;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint.OperationRequestHandler
{
    class WorldOperationRequestBroker : OperationRequestHandler<Core.Internal.EndPoint, Core.Internal.EndPoint, EndPointOperationCode>
    {
        public WorldOperationRequestBroker() : base(typeof(WorldOperationRequestParameterCode))
        {
        }

        public override void SendResponse(Core.Internal.EndPoint terminal, Core.Internal.EndPoint target, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(Core.Internal.EndPoint terminal, Core.Internal.EndPoint requester, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)WorldOperationRequestParameterCode.DeviceId];
                int worldId = (int)parameters[(byte)WorldOperationRequestParameterCode.WorldId];
                WorldOperationCode worldOperationCode = (WorldOperationCode)parameters[(byte)WorldOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)WorldOperationRequestParameterCode.Parameters];
                Core.World world;
                if (CommunicationService.Instance.FindWorld(worldId, out world))
                {
                    return WorldOperationRequestRouter.Instance.Route(terminal, deviceId, world, worldOperationCode, operationRequestParameters, out errorMessage);
                }
                else
                {
                    WorldOperationRequestApi.SendOperationRequest(terminal.DeviceId, worldId, (Protocol.Internal.World.WorldOperationCode)worldOperationCode, operationRequestParameters);
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
