using Door_of_Soul.Communication.SceneServer.Scene;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.Device.OperationRequestHandler
{
    class SceneOperationRequestBroker : OperationRequestHandler<TerminalDevice, DeviceOperationCode>
    {
        public SceneOperationRequestBroker() : base(typeof(SceneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalDevice terminal, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, operationCode, parameters, out errorMessage))
            {
                int worldId = (int)parameters[(byte)SceneOperationRequestParameterCode.WorldId];
                int sceneId = (int)parameters[(byte)SceneOperationRequestParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationRequestParameterCode.Parameters];
                TerminalScene scene;
                if (CommunicationService.Instance.FindScene(sceneId, out scene) && scene.WorldId == worldId)
                {
                    return SceneOperationRequestRouter.Instance.Route(terminal, scene as TerminalScene, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SceneId:{sceneId} in WorldId:{worldId}";
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
