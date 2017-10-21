using Door_of_Soul.Communication.Client.System;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.EventHandler
{
    class SystemEventBroker : BasicEventHandler
    {
        public SystemEventBroker() : base(typeof(SystemEventParameterCode))
        {
        }

        public override OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                SystemEventCode resolvedEventCode = (SystemEventCode)parameters[(byte)SystemEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SystemEventParameterCode.Parameters];
                returnCode = SystemEventRouter.Instance.Route(VirtualSystem.Instance, resolvedEventCode, resolvedParameters, out errorMessage);
            }
            return returnCode;
        }
    }
}
