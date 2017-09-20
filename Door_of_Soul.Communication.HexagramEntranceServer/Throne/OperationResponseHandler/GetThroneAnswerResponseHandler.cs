using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationResponseParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.OperationResponseHandler
{
    class GetThroneAnswerResponseHandler : OperationResponseHandler<ThroneOperationCode>
    {
        public GetThroneAnswerResponseHandler() : base(typeof(GetThroneAnswerResponseParameterCode))
        {
        }

        public override bool Handle(ThroneOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)GetThroneAnswerResponseParameterCode.AnswerId];
                string answerName = (string)parameters[(byte)GetThroneAnswerResponseParameterCode.AnswerName];
                int[] soulIds = (int[])parameters[(byte)GetThroneAnswerResponseParameterCode.SoulIds];
                VirtualSystem.Instance.GetThroneAnswerResponse(returnCode, operationMessage, answerId, answerName, soulIds);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
