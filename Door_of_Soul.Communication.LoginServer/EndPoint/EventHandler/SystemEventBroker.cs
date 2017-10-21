using Door_of_Soul.Communication.LoginServer.System;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.LoginServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.EndPoint.EventHandler
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
