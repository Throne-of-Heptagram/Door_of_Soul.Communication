using Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device.OperationRequestHandler
{
    class SceneOperationRequestBroker : OperationRequestHandler<Core.Device, DeviceOperationCode>
    {
        public SceneOperationRequestBroker() : base(typeof(SceneOperationRequestParameterCode))
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
                int worldId = (int)parameters[(byte)SceneOperationRequestParameterCode.WorldId];
                int sceneId = (int)parameters[(byte)SceneOperationRequestParameterCode.SceneId];
                int observerAvatarId = (int)parameters[(byte)SceneOperationRequestParameterCode.ObserverAvatarId];
                SceneOperationCode sceneOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationRequestParameterCode.Parameters];
                Core.World world;
                Core.Scene scene;
                if (CommunicationService.Instance.FindWorld(worldId, out world) && world.FindScene(sceneId, out scene) && scene.ObserverAvatarId == observerAvatarId)
                {
                    return SceneOperationRequestRouter.Instance.Route(scene, sceneOperationCode, operationRequestParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SceneId:{sceneId} in WorldId:{worldId}, ObserverAvatarId:{observerAvatarId}";
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
