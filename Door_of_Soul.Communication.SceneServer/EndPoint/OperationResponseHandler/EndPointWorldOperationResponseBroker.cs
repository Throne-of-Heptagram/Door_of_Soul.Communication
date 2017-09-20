using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Communication.SceneServer.World;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.SceneServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.EndPoint.OperationResponseHandler
{
    class EndPointWorldOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public EndPointWorldOperationResponseBroker() : base(typeof(EndPointWorldOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)EndPointWorldOperationResponseParameterCode.WorldId];
                WorldOperationCode resolvedOperationCode = (WorldOperationCode)parameters[(byte)EndPointWorldOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)EndPointWorldOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)EndPointWorldOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointWorldOperationResponseParameterCode.Parameters];
                VirtualWorld world;
                if (ResourceService.Instance.FindWorld(worldId, out world))
                {
                    return WorldOperationResponseRouter.Instance.Route(world, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
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
