using System;

namespace Door_of_Soul.Communication.SceneServer
{
    public abstract class TerminalDevice
    {
        public event Action<TerminalDevice, TerminalScene> OnSceneLinked;
        public event Action<TerminalDevice, TerminalScene> OnSceneUnlinked;

        public int DeviceId { get; private set; }
        public TerminalScene Scene { get; private set; }

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
