using Door_of_Soul.Communication.HexagramEntranceServer.World;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Communication.Protocol.Hexagram.Space.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Space.OperationResponseHandler
{
    class WorldOperationResponseBroker : OperationResponseHandler<SpaceOperationCode>
    {
        public WorldOperationResponseBroker() : base(typeof(WorldOperationResponseParameterCode))
        {
        }

        public override bool Handle(SpaceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int endPointId = (int)parameters[(byte)WorldOperationResponseParameterCode.EndPointId];
                int deviceId = (int)parameters[(byte)WorldOperationResponseParameterCode.DeviceId];
                int worldId = (int)parameters[(byte)WorldOperationResponseParameterCode.WorldId];
                WorldOperationCode resolvedOperationCode = (WorldOperationCode)parameters[(byte)WorldOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)WorldOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)WorldOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)WorldOperationResponseParameterCode.Parameters];
                TerminalEndPoint endPoint;
                if (CommunicationService.Instance.FindEndPoint(endPointId, out endPoint))
                {
                    WorldOperationResponseApi.SendOperationResponse(endPoint, deviceId, worldId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters);
                    return true;
                }
                else
                {
                    errorMessage = $"Can not find EndPointId:{endPointId}";
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
