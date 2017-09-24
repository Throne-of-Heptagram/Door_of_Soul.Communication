using Door_of_Soul.Communication.HexagramEntranceServer.System;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.Device.OperationResponseHandler
{
    class RegisterResponseHandler : L2SubjectOperationResponseHandler<TerminalEndPoint, int, DeviceThroneOperationCode>
    {
        public RegisterResponseHandler() : base(typeof(RegisterResponseParameterCode))
        {
        }

        public override bool Handle(TerminalEndPoint subject, int l2TerminalId, DeviceThroneOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, l2TerminalId, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                SystemOperationResponseApi.SendDeviceOperationResponse(subject, l2TerminalId, SystemOperationCode.DeviceRegister, returnCode, operationMessage, parameters);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
