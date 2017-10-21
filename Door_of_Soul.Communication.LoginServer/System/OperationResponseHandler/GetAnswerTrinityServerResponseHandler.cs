using Door_of_Soul.Communication.Protocol.Internal.System.OperationResponseParameter;
using Door_of_Soul.Core.LoginServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System.OperationResponseHandler
{
    class GetAnswerTrinityServerResponseHandler : SubjectOperationResponseHandler<VirtualSystem>
    {
        public GetAnswerTrinityServerResponseHandler() : base(typeof(GetAnswerTrinityServerResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(VirtualSystem subject, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(subject, returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int trinityServerEndPointId = (int)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.TrinityServerEndPointId];
                int answerId = (int)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.AnswerId];
                string answerAccessToken = (string)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.AnswerAccessToken];
                subject.GetAnswerTrinityServerResponse(new VirtualSystem.GetAnswerTrinityServerResponseParameter
                {
                    returnCode = returnCode,
                    operationMessage = operationMessage,
                    trinityServerEndPointId = trinityServerEndPointId,
                    answerId = answerId,
                    answerAccessToken = answerAccessToken
                });
            }
            else
            {
                subject.GetAnswerTrinityServerResponse(new VirtualSystem.GetAnswerTrinityServerResponseParameter
                {
                    returnCode = returnCode,
                    operationMessage = operationMessage,
                    trinityServerEndPointId = default(int),
                    answerId = default(int),
                    answerAccessToken = default(string)
                });
            }
            return returnCode;
        }
    }
}
