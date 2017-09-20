using Door_of_Soul.Communication.HexagramEntranceServer.World;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class EndPointWorldOperationRequestBroker : OperationRequestHandler<TerminalEndPoint, EndPointOperationCode>
    {
        public EndPointWorldOperationRequestBroker() : base(typeof(EndPointWorldOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint target, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)EndPointWorldOperationRequestParameterCode.WorldId];
                WorldOperationCode resolvedOperationCode = (WorldOperationCode)parameters[(byte)EndPointWorldOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointWorldOperationRequestParameterCode.Parameters];
                VirtualWorld world;
                if (ResourceService.Instance.FindWorld(worldId, out world))
                {
                    return WorldOperationRequestRouter.Instance.Route(terminal, world, resolvedOperationCode, resolvedParameters, out errorMessage);
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
