using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.ObserverServer.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.EndPoint.OperationResponseHandler
{
    class SceneOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public SceneOperationResponseBroker() : base(typeof(SceneOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int sceneId = (int)parameters[(byte)SceneOperationResponseParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)SceneOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)SceneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationResponseParameterCode.Parameters];
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
