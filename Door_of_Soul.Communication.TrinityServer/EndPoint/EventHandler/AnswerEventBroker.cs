using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.EventParameter;
using Door_of_Soul.Communication.TrinityServer.Answer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.EventHandler
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
                TerminalAnswer answer;
                if(ResourceService.Instance.FindAnswer(answerId, out answer))
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
