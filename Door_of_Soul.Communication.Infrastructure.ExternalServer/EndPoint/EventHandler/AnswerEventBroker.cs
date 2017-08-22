using Door_of_Soul.Communication.Infrastructure.ExternalServer.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.EndPoint.EventHandler
{
    class AnswerEventBroker : EventHandler<Core.InternalServer.EndPoint, EndPointEventCode>
    {
        public AnswerEventBroker() : base(typeof(AnswerEventParameterCode))
        {
        }

        public override bool Handle(Core.InternalServer.EndPoint subject, EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
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
