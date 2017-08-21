using Door_of_Soul.Communication.Infrastructure.Client.System;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.EventHandler
{
    class SystemEventBroker : EventHandler<Core.Device, DeviceEventCode>
    {
        public SystemEventBroker() : base(typeof(SystemEventParameterCode))
        {
        }

        internal override bool Handle(Core.Device subject, DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                SystemEventCode systemEventCode = (SystemEventCode)parameters[(byte)SystemEventParameterCode.EventCode];
                Dictionary<byte, object> eventParameters = (Dictionary<byte, object>)parameters[(byte)SystemEventParameterCode.Parameters];
                return SystemEventRouter.Instance.Route(Core.System.Instance, systemEventCode, eventParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
