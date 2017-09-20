using Door_of_Soul.Communication.HexagramEntranceServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class EndPointSceneOperationRequestBroker : OperationRequestHandler<TerminalEndPoint, EndPointOperationCode>
    {
        public EndPointSceneOperationRequestBroker() : base(typeof(EndPointSceneOperationRequestParameterCode))
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
                int sceneId = (int)parameters[(byte)EndPointSceneOperationRequestParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)EndPointSceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointSceneOperationRequestParameterCode.Parameters];
                VirtualScene scene;
                if (ResourceService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneOperationRequestRouter.Instance.Route(terminal, scene, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SceneId:{sceneId}";
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
