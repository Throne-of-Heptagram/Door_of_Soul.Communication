using Door_of_Soul.Communication.Infrastructure.Client.Scene;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.EventHandler
{
    class SceneEventBroker : EventHandler<Core.Device, DeviceEventCode>
    {
        public SceneEventBroker() : base(typeof(SceneEventParameterCode))
        {
        }

        internal override bool Handle(Core.Device subject, DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                int sceneId = (int)parameters[(byte)SceneEventParameterCode.SceneId];
                SceneEventCode sceneEventCode = (SceneEventCode)parameters[(byte)SceneEventParameterCode.EventCode];
                Dictionary<byte, object> eventParameters = (Dictionary<byte, object>)parameters[(byte)SceneEventParameterCode.Parameters];
                Core.Scene scene;
                if (CommunicationService.Instance.FindScene(sceneId, out scene))
                {
                    return SceneEventRouter.Instance.Route(scene, sceneEventCode, eventParameters, out errorMessage);
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
