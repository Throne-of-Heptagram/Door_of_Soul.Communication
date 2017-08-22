using Door_of_Soul.Communication.Infrastructure.Client.Answer;
using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Device;
using Door_of_Soul.Communication.Protocol.External.Device.EventParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Device.EventHandler
{
    class AnswerEventBroker : EventHandler<Core.Device, DeviceEventCode>
    {
        public AnswerEventBroker() : base(typeof(AnswerEventParameterCode))
        {
        }

        public override bool Handle(Core.Device subject, DeviceEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if(base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)AnswerEventParameterCode.AnswerId];
                AnswerEventCode answerEventCode = (AnswerEventCode)parameters[(byte)AnswerEventParameterCode.EventCode];
                Dictionary<byte, object> eventParameters = (Dictionary<byte, object>)parameters[(byte)AnswerEventParameterCode.Parameters];
                Core.Answer answer;
                if(CommunicationService.Instance.FindAnswer(answerId, out answer))
                {
                    return AnswerEventRouter.Instance.Route(answer, answerEventCode, eventParameters, out errorMessage);
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
