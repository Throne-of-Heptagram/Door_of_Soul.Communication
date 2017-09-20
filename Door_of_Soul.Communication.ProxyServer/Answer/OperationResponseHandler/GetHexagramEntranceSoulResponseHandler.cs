using Door_of_Soul.Communication.Protocol.Internal.Answer;
using Door_of_Soul.Communication.Protocol.Internal.Answer.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Answer.OperationResponseHandler
{
    class GetHexagramEntranceSoulResponseHandler : OperationResponseHandler<TerminalAnswer, AnswerOperationCode>
    {
        public GetHexagramEntranceSoulResponseHandler() : base(typeof(GetHexagramEntranceSoulResponseParameterCode))
        {
        }

        public override bool Handle(TerminalAnswer subject, AnswerOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)GetHexagramEntranceSoulResponseParameterCode.SoulId];
                string soulName = (string)parameters[(byte)GetHexagramEntranceSoulResponseParameterCode.SoulName];
                bool isActivated = (bool)parameters[(byte)GetHexagramEntranceSoulResponseParameterCode.IsActivated];
                int answerId = (int)parameters[(byte)GetHexagramEntranceSoulResponseParameterCode.AnswerId];
                int[] avatarIds = (int[])parameters[(byte)GetHexagramEntranceSoulResponseParameterCode.AvatarIds];
                subject.GetHexagramEntranceSoulResponse(returnCode, operationMessage, soulId, soulName, isActivated, answerId, avatarIds);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
