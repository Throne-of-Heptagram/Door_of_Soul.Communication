using Door_of_Soul.Communication.Protocol.External.System.OperationResponseParameter;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.System.OperationResponseHandler
{
    class RegisterResponseHandler : SubjectOperationResponseHandler<VirtualSystem>
    {
        public RegisterResponseHandler() : base(typeof(RegisterResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(VirtualSystem subject, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(subject, returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                subject.RegisterResponse(returnCode, operationMessage);
            }
            else
            {
                subject.RegisterResponse(returnCode, operationMessage);
            }
            return returnCode;
        }
    }
}
