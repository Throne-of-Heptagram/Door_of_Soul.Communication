﻿using Door_of_Soul.Communication.HexagramEntranceServer.World;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class WorldOperationRequestBroker : OperationRequestHandler<TerminalEndPoint, EndPointOperationCode>
    {
        public WorldOperationRequestBroker() : base(typeof(WorldOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint terminal, EndPointOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, EndPointOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)WorldOperationRequestParameterCode.WorldId];
                WorldOperationCode resolvedOperationCode = (WorldOperationCode)parameters[(byte)WorldOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)WorldOperationRequestParameterCode.Parameters];
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
