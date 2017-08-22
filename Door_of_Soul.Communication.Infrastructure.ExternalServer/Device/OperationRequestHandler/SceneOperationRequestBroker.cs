using Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device.OperationRequestHandler
{
    class SceneOperationRequestBroker : OperationRequestHandler<Core.Device, Core.Device, DeviceOperationCode>
    {
        public SceneOperationRequestBroker() : base(typeof(SceneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(Core.Device terminal, Core.Device target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(Core.Device terminal, Core.Device requester, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int sceneId = (int)parameters[(byte)SceneOperationRequestParameterCode.SceneId];
                SceneOperationCode sceneOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationRequestParameterCode.Parameters];
                Core.Scene scene;
                if (CommunicationService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneOperationRequestRouter.Instance.Route(terminal, scene, sceneOperationCode, operationRequestParameters, out errorMessage);
                }
                else
                {
                    SceneOperationRequestApi.SendOperationRequest(terminal.DeviceId, sceneId, (Protocol.Internal.Scene.SceneOperationCode)sceneOperationCode, operationRequestParameters);
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
