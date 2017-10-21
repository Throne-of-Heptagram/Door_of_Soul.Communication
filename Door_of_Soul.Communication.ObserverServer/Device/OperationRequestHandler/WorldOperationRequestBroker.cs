using Door_of_Soul.Communication.ObserverServer.World;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.ObserverServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.Device.OperationRequestHandler
{
    class WorldOperationRequestBroker : BasicOperationRequestHandler<TerminalDevice>
    {
        public WorldOperationRequestBroker() : base(typeof(WorldOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, DeviceOperationCode.WorldOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalDevice terminal, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int worldId = (int)parameters[(byte)WorldOperationRequestParameterCode.WorldId];
                WorldOperationCode resolvedOperationCode = (WorldOperationCode)parameters[(byte)WorldOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)WorldOperationRequestParameterCode.Parameters];
                VirtualWorld world;
                if (ResourceService.Instance.FindWorld(worldId, out world))
                {
                    returnCode = WorldOperationRequestRouter.Instance.Route(terminal, world, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find WorldId:{worldId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
