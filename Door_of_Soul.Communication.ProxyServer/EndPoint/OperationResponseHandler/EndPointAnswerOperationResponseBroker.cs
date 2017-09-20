using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.ProxyServer.Answer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint.OperationResponseHandler
{
    class EndPointAnswerOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public EndPointAnswerOperationResponseBroker() : base(typeof(EndPointAnswerOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)EndPointAnswerOperationResponseParameterCode.AnswerId];
                AnswerOperationCode resolvedOperationCode = (AnswerOperationCode)parameters[(byte)EndPointAnswerOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)EndPointAnswerOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)EndPointAnswerOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)EndPointAnswerOperationResponseParameterCode.Parameters];
                TerminalAnswer answer;
                if (ResourceService.Instance.FindAnswer(answerId, out answer))
                {
                    return AnswerOperationResponseRouter.Instance.Route(answer, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
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
