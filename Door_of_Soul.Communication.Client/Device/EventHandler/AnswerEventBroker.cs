using Door_of_Soul.Communication.Client.Answer;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using Door_of_Soul.Core.Client;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Client.Device.EventHandler
{
    class AnswerEventBroker : BasicEventHandler
    {
        public AnswerEventBroker() : base(typeof(AnswerEventParameterCode))
        {
        }

        public override OperationReturnCode Handle(Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int answerId = (int)parameters[(byte)AnswerEventParameterCode.AnswerId];
                AnswerEventCode resolvedEventCode = (AnswerEventCode)parameters[(byte)AnswerEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)AnswerEventParameterCode.Parameters];
                VirtualAnswer answer;
                if(CommunicationService.Instance.FindAnswer(answerId, out answer))
                {
                    returnCode = AnswerEventRouter.Instance.Route(answer, resolvedEventCode, resolvedParameters, out errorMessage);
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
