using Door_of_Soul.Communication.ProxyServer.System;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint.EventHandler
{
    class SystemEventBroker : EventHandler<EndPointEventCode>
    {
        public SystemEventBroker() : base(typeof(SystemEventParameterCode))
        {
        }

        public override bool Handle(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(eventCode, parameters, out errorMessage))
            {
                SystemEventCode resolvedEventCode = (SystemEventCode)parameters[(byte)SystemEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SystemEventParameterCode.Parameters];
                return SystemEventRouter.Instance.Route(Core.System.Instance, resolvedEventCode, resolvedParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
