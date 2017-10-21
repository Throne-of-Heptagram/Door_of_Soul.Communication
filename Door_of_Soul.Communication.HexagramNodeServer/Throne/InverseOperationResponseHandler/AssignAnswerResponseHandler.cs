using Door_of_Soul.Communication.Protocol.Hexagram.Throne.InverseOperationResponseParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.InverseOperationResponseHandler
{
    class AssignAnswerResponseHandler : SubjectInverseOperationResponseHandler<ThroneHexagramEntrance, VirtualThrone>
    {
        public AssignAnswerResponseHandler() : base(typeof(AssignAnswerResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(ThroneHexagramEntrance terminal, VirtualThrone subject, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(terminal, subject, returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int trinityServerEndPointId = (int)parameters[(byte)AssignAnswerResponseParameterCode.TrinityServerEndPointId];
                int answerId = (int)parameters[(byte)AssignAnswerResponseParameterCode.AnswerId];
                string answerAccessToken = (string)parameters[(byte)AssignAnswerResponseParameterCode.AnswerAccessToken];

                subject.AssignAnswerResponse(new VirtualThrone.AssignAnswerResponseParameter
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
                subject.AssignAnswerResponse(new VirtualThrone.AssignAnswerResponseParameter
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
