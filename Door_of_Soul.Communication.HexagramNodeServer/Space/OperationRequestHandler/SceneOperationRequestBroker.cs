using Door_of_Soul.Communication.HexagramNodeServer.Space.Scene;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Communication.Protocol.Hexagram.Space.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space.OperationRequestHandler
{
    class SceneOperationRequestBroker : OperationRequestHandler<TerminalHexagramEntrance, SpaceOperationCode>
    {
        public SceneOperationRequestBroker() : base(typeof(SceneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalHexagramEntrance target, SpaceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SpaceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalHexagramEntrance terminal, SpaceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int endPointId = (int)parameters[(byte)SceneOperationRequestParameterCode.EndPointId];
                int deviceId = (int)parameters[(byte)SceneOperationRequestParameterCode.DeviceId];
                int worldId = (int)parameters[(byte)SceneOperationRequestParameterCode.WorldId];
                int sceneId = (int)parameters[(byte)SceneOperationRequestParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationRequestParameterCode.Parameters];
                Core.Scene scene;
                if (EntranceCommunicationService<SpaceEventCode, SpaceOperationCode>.Instance.FindScene(sceneId, out scene) && scene.WorldId == worldId)
                {
                    return SceneOperationRequestRouter.Instance.Route(terminal, endPointId, deviceId, scene, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SceneId:{sceneId} in WorldId:{worldId}. requested from EndPointId:{endPointId}, DeviceId:{deviceId}";
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
