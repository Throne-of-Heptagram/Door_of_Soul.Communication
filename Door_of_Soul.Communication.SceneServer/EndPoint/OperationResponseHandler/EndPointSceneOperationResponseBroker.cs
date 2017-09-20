using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.SceneServer.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.EndPoint.OperationResponseHandler
{
    class EndPointSceneOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public EndPointSceneOperationResponseBroker() : base(typeof(EndPointSceneOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int sceneId = (int)parameters[(byte)EndPointSceneOperationResponseParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)EndPointSceneOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)EndPointSceneOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)EndPointSceneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointSceneOperationResponseParameterCode.Parameters];
                TerminalScene scene;
                if (ResourceService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneOperationResponseRouter.Instance.Route(scene, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
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
