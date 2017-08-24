using Door_of_Soul.Communication.Infrastructure.InternalServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint.OperationRequestHandler
{
    class SceneOperationRequestBroker : OperationRequestHandler<Core.Internal.EndPoint, Core.Internal.EndPoint, EndPointOperationCode>
    {
        public SceneOperationRequestBroker() : base(typeof(SceneOperationRequestParameterCode))
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
                int deviceId = (int)parameters[(byte)SceneOperationRequestParameterCode.DeviceId];
                int sceneId = (int)parameters[(byte)SceneOperationRequestParameterCode.SceneId];
                SceneOperationCode sceneOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationRequestParameterCode.Parameters];
                Core.Scene scene;
                if (CommunicationService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneOperationRequestRouter.Instance.Route(terminal, deviceId, scene, sceneOperationCode, operationRequestParameters, out errorMessage);
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
