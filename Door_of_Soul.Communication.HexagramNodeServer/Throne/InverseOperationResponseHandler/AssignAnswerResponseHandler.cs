using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.InverseOperationResponseParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.InverseOperationResponseHandler
{
    class AssignAnswerResponseHandler : SubjectInverseOperationResponseHandler<ThroneHexagramEntrance, VirtualThrone, ThroneInverseOperationCode>
    {
        public AssignAnswerResponseHandler() : base(typeof(AssignAnswerResponseParameterCode))
        {
        }

        public override bool Handle(ThroneHexagramEntrance terminal, VirtualThrone subject, ThroneInverseOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int trinityServerEndPointId = (int)parameters[(byte)AssignAnswerResponseParameterCode.TrinityServerEndPointId];
                int answerId = (int)parameters[(byte)AssignAnswerResponseParameterCode.AnswerId];
                string answerAccessToken = (string)parameters[(byte)AssignAnswerResponseParameterCode.AnswerAccessToken];

                subject.AssignAnswerResponse(
                    returnCode: returnCode,
                    operationMessage: operationMessage,
                    trinityServerEndPointId: trinityServerEndPointId,
                    answerId: answerId,
                    answerAccessToken: answerAccessToken);
                return true;
            }
            else
            {
                subject.AssignAnswerResponse(
                    returnCode: returnCode,
                    operationMessage: operationMessage,
                    trinityServerEndPointId: default(int),
                    answerId: default(int),
                    answerAccessToken: default(string));
                return false;
            }
        }
    }
}
