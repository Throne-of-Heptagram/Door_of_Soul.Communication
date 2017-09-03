using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Core.Protocol;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer
{
    public class TerminalDevice
    {
        public delegate void SendEventDelegate(DeviceEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public event Action<TerminalDevice, TerminalScene> OnSceneLinked;
        public event Action<TerminalDevice, TerminalScene> OnSceneUnlinked;

        public int DeviceId { get; private set; }
        public TerminalScene Scene { get; private set; }

        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }

        public TerminalDevice(int deviceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod)
        {
            DeviceId = deviceId;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
        }

        public bool IsSceneLinked(int sceneId)
        {
            return Scene?.SceneId == sceneId;
        }
        public bool LinkScene(TerminalScene scene)
        {
            if (Scene != scene)
            {
                if (Scene != null)
                {
                    UnlinkScene();
                }
                Scene = scene;
                if (!Scene.IsDeviceLinked(this))
                {
                    Scene.LinkDevice(this);
                }
                OnSceneLinked?.Invoke(this, Scene);
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool UnlinkScene()
        {
            if (Scene != null)
            {
                if (Scene.IsDeviceLinked(this))
                {
                    Scene.UnlinkDevice(this);
                }
                TerminalScene scene = Scene;
                Scene = null;
                OnSceneUnlinked?.Invoke(this, scene);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
