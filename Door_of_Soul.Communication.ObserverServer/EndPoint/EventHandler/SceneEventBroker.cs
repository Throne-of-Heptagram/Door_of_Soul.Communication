using Door_of_Soul.Communication.ObserverServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.EndPoint.EventHandler
{
    class SceneEventBroker : EventHandler<EndPointEventCode>
    {
        public SceneEventBroker() : base(typeof(SceneEventParameterCode))
        {
        }

        public override bool Handle(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(eventCode, parameters, out errorMessage))
            {
                int sceneId = (int)parameters[(byte)SceneEventParameterCode.SceneId];
                SceneEventCode resolvedEventCode = (SceneEventCode)parameters[(byte)SceneEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SceneEventParameterCode.Parameters];
                TerminalScene scene;
                if (ResourceService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneEventRouter.Instance.Route(scene, resolvedEventCode, resolvedParameters, out errorMessage);
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
