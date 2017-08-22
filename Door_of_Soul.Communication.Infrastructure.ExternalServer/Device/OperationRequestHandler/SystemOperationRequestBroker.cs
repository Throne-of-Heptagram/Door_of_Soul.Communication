using Door_of_Soul.Communication.Infrastructure.ExternalServer.System;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Device.OperationRequestHandler
{
    class SystemOperationRequestBroker : OperationRequestHandler<Core.Device, Core.Device, DeviceOperationCode>
    {
        public SystemOperationRequestBroker() : base(typeof(SystemOperationRequestParameterCode))
        {
        }

        public override void SendResponse(Core.Device terminal, Core.Device target, DeviceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(Core.Device terminal, Core.Device requester, DeviceOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                SystemOperationCode systemOperationCode = (SystemOperationCode)parameters[(byte)SystemOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> operationRequestParameters = (Dictionary<byte, object>)parameters[(byte)SystemOperationRequestParameterCode.Parameters];
                return SystemOperationRequestRouter.Instance.Route(terminal, Core.System.Instance, systemOperationCode, operationRequestParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
