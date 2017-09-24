using Door_of_Soul.Core.ObserverServer;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer
{
    public abstract class TerminalScene : VirtualScene
    {
        public event Action<TerminalScene, TerminalDevice> OnDeviceLinked;
        public event Action<TerminalScene, TerminalDevice> OnDeviceUnlinked;

        private object devicesLock = new object();
        private List<TerminalDevice> devices = new List<TerminalDevice>();

        public IEnumerable<TerminalDevice> Devices
        {
            get
            {
                lock (devicesLock)
                {
                    return devices.ToArray();
                }
            }
        }

        public bool IsDeviceLinked(TerminalDevice device)
        {
            return devices.Contains(device);
        }
        public bool LinkDevice(TerminalDevice device)
        {
            lock (devicesLock)
            {
                if (IsDeviceLinked(device))
                {
                    return false;
                }
                else
                {
                    devices.Add(device);
                    if(!device.IsSceneLinked(SceneId))
                    {
                        device.LinkScene(this);
                    }
                    OnDeviceLinked?.Invoke(this, device);
                    return true;
                }
            }
        }
        public bool UnlinkDevice(TerminalDevice device)
        {
            lock (devicesLock)
            {
                if (!IsDeviceLinked(device))
                {
                    return false;
                }
                else
                {
                    if (devices.Remove(device))
                    {
                        device.UnlinkScene();
                        OnDeviceUnlinked?.Invoke(this, device);
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }
    }
}
