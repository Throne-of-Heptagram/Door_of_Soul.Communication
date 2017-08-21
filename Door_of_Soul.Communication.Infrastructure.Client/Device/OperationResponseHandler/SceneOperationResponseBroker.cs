using Door_of_Soul.Communication.Infrastructure.Client.Scene;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.OperationResponseHandler
{
    class SceneOperationResponseBroker : OperationResponseHandler<Core.Device, DeviceOperationCode>
    {
        public SceneOperationResponseBroker() : base(typeof(SceneOperationResponseParameterCode))
        {
        }

        internal override bool Handle(Core.Device subject, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int sceneId = (int)parameters[(byte)SceneOperationResponseParameterCode.SceneId];
                SceneOperationCode sceneOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationResponseParameterCode.OperationCode];
                OperationReturnCode sceneOperationReturnCode = (OperationReturnCode)parameters[(byte)SceneOperationResponseParameterCode.OperationReturnCode];
                string answerOperationMessage = (string)parameters[(byte)SceneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationResponseParameterCode.Parameters];
                Core.Scene scene;
                if (CommunicationService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneOperationResponseRouter.Instance.Route(scene, sceneOperationCode, sceneOperationReturnCode, answerOperationMessage, operationResponseParameters, out errorMessage);
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
