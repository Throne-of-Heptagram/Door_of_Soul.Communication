using Door_of_Soul.Communication.Infrastructure.Client.System;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.OperationResponseHandler
{
    class SystemOperationResponseBroker : OperationResponseHandler<Core.Device, Core.Device, DeviceOperationCode>
    {
        public SystemOperationResponseBroker() : base(typeof(SystemOperationResponseParameterCode))
        {
        }

        public override bool Handle(Core.Device terminal, Core.Device subject, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                SystemOperationCode systemOperationCode = (SystemOperationCode)parameters[(byte)SystemOperationResponseParameterCode.OperationCode];
                OperationReturnCode systemOperationReturnCode = (OperationReturnCode)parameters[(byte)SystemOperationResponseParameterCode.OperationReturnCode];
                string systemOperationMessage = (string)parameters[(byte)SystemOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)SystemOperationResponseParameterCode.Parameters];
                return SystemOperationResponseRouter.Instance.Route(terminal, Core.System.Instance, systemOperationCode, systemOperationReturnCode, systemOperationMessage, operationResponseParameters, out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
