using Door_of_Soul.Core.TrinityServer;
using System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer
{
    public abstract class TerminalAnswer : VirtualAnswer
    {
        public event Action<TerminalAnswer, TerminalDevice> OnDeviceLinked;
        public event Action<TerminalAnswer, TerminalDevice> OnDeviceUnlinked;

        private object devicesLock = new object();
        private List<TerminalDevice> devices = new List<TerminalDevice>();

        protected TerminalAnswer(int answerId, string answerName) : base(answerId, answerName)
        {
        }

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
                    if(!device.IsAnswerLinked(AnswerId))
                    {
                        device.LinkAnswer(this);
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
                        device.UnlinkAnswer();
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
