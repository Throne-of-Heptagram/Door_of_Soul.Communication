using Door_of_Soul.Communication.Infrastructure.Client.Answer;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.OperationResponseHandler
{
    class AnswerOperationResponseBroker : OperationResponseHandler<Core.Device, Core.Device, DeviceOperationCode>
    {
        public AnswerOperationResponseBroker() : base(typeof(AnswerOperationResponseParameterCode))
        {
        }

        public override bool Handle(Core.Device terminal, Core.Device subject, DeviceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if(base.Handle(terminal, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)AnswerOperationResponseParameterCode.AnswerId];
                AnswerOperationCode answerOperationCode = (AnswerOperationCode)parameters[(byte)AnswerOperationResponseParameterCode.OperationCode];
                OperationReturnCode answerOperationReturnCode = (OperationReturnCode)parameters[(byte)AnswerOperationResponseParameterCode.OperationReturnCode];
                string answerOperationMessage = (string)parameters[(byte)AnswerOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> operationResponseParameters = (Dictionary<byte, object>)parameters[(byte)AnswerOperationResponseParameterCode.Parameters];
                Core.Answer answer;
                if (CommunicationService.Instance.FindAnswer(answerId, out answer))
                {
                    return AnswerOperationResponseRouter.Instance.Route(terminal, answer, answerOperationCode, answerOperationReturnCode, answerOperationMessage, operationResponseParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find AnswerId:{answerId}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
