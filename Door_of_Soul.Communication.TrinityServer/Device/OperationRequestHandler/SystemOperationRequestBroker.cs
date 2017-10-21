using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.TrinityServer.System;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.TrinityServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Device.OperationRequestHandler
{
    class SystemOperationRequestBroker : BasicOperationRequestHandler<TerminalDevice>
    {
        public SystemOperationRequestBroker() : base(typeof(SystemOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, DeviceOperationCode.SystemOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalDevice terminal, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                SystemOperationCode resolvedOperationCode = (SystemOperationCode)parameters[(byte)SystemOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SystemOperationRequestParameterCode.Parameters];
                returnCode = SystemOperationRequestRouter.Instance.Route(terminal, VirtualSystem.Instance, resolvedOperationCode, resolvedParameters, out errorMessage);
            }
            return returnCode;
        }
    }
}
