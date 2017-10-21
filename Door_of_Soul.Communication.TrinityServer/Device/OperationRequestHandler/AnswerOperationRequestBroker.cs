using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationRequestParameter;
using Door_of_Soul.Communication.TrinityServer.Answer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Device.OperationRequestHandler
{
    class AnswerOperationRequestBroker : BasicOperationRequestHandler<TerminalDevice>
    {
        public AnswerOperationRequestBroker() : base(typeof(AnswerOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalDevice target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SendOperationResponse(target, DeviceOperationCode.AnswerOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalDevice terminal, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int answerId = (int)parameters[(byte)AnswerOperationRequestParameterCode.AnswerId];
                AnswerOperationCode resolvedOperationCode = (AnswerOperationCode)parameters[(byte)AnswerOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)AnswerOperationRequestParameterCode.Parameters];
                if (terminal.IsAnswerLinked(answerId))
                {
                    return AnswerOperationRequestRouter.Instance.Route(terminal, terminal.Answer, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find AnswerId:{answerId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
