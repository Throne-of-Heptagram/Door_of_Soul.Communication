using Door_of_Soul.Communication.Infrastructure.ExternalServer.System;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint.EventHandler
{
    class SystemEventBroker : EventHandler<Core.InternalServer.EndPoint, EndPointEventCode>
    {
        public SystemEventBroker() : base(typeof(SystemEventParameterCode))
        {
        }

        public override bool Handle(Core.InternalServer.EndPoint subject, EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
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
