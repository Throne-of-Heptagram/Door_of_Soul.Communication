using Door_of_Soul.Communication.HexagramEntranceServer.System;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.Device.OperationResponseHandler
{
    class RegisterResponseHandler : L2SubjectOperationResponseHandler<TerminalEndPoint, int>
    {
        public RegisterResponseHandler() : base(typeof(RegisterResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(TerminalEndPoint subject, int l2TerminalId, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(subject, l2TerminalId, returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                SystemOperationResponseApi.SendDeviceOperationResponse(subject, l2TerminalId, SystemOperationCode.DeviceRegister, returnCode, operationMessage, parameters);
            }
            return returnCode;
        }
    }
}
