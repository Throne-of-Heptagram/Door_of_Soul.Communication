using Door_of_Soul.Communication.Infrastructure.ExternalServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint.OperationResponseHandler
{
    class SceneOperationResponseBroker : OperationResponseHandler<Core.InternalServer.EndPoint, Core.InternalServer.EndPoint, EndPointOperationCode>
    {
        public SceneOperationResponseBroker() : base(typeof(SceneOperationResponseParameterCode))
        {
        }

        public override bool Handle(Core.InternalServer.EndPoint terminal, Core.InternalServer.EndPoint subject, EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int sceneId = (int)parameters[(byte)SceneOperationResponseParameterCode.SceneId];
                SceneOperationCode sceneOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationResponseParameterCode.OperationCode];
                OperationReturnCode sceneOperationReturnCode = (OperationReturnCode)parameters[(byte)SceneOperationResponseParameterCode.OperationReturnCode];
                string answerOperationMessage = (string)parameters[(byte)SceneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationResponseParameterCode.Parameters];
                Core.Scene scene;
                if (CommunicationService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneOperationResponseRouter.Instance.Route(terminal, scene, sceneOperationCode, sceneOperationReturnCode, answerOperationMessage, operationResponseParameters, out errorMessage);
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
