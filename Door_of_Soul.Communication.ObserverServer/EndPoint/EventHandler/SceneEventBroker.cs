using Door_of_Soul.Communication.ObserverServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.EndPoint.EventHandler
{
    class SceneEventBroker : BasicEventHandler
    {
        public SceneEventBroker() : base(typeof(SceneEventParameterCode))
        {
        }

        public override OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int sceneId = (int)parameters[(byte)SceneEventParameterCode.SceneId];
                SceneEventCode resolvedEventCode = (SceneEventCode)parameters[(byte)SceneEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SceneEventParameterCode.Parameters];
                TerminalScene scene;
                if (ResourceService.Instance.FindScene(sceneId, out scene))
                {
                    returnCode = SceneEventRouter.Instance.Route(scene, resolvedEventCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SceneId:{sceneId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
