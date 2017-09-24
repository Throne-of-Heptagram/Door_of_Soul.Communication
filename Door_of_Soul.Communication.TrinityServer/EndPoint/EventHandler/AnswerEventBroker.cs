using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.TrinityServer.Answer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.EventHandler
{
    class AnswerEventBroker : EventHandler<EndPointEventCode>
    {
        public AnswerEventBroker() : base(typeof(AnswerEventParameterCode))
        {
        }

        public override bool Handle(EndPointEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if(base.Handle(eventCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)AnswerEventParameterCode.AnswerId];
                AnswerEventCode resolvedEventCode = (AnswerEventCode)parameters[(byte)AnswerEventParameterCode.EventCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)AnswerEventParameterCode.Parameters];
                TerminalAnswer answer;
                if(ResourceService.Instance.FindAnswer(answerId, out answer))
                {
                    return AnswerEventRouter.Instance.Route(answer, resolvedEventCode, resolvedParameters, out errorMessage);
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
