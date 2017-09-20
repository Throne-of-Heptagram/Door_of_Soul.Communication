using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Communication.Protocol.Hexagram.Will.OperationResponseParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Will.OperationResponseHandler
{
    class GetWillSoulResponseHandler : OperationResponseHandler<WillOperationCode>
    {
        public GetWillSoulResponseHandler() : base(typeof(GetWillSoulResponseParameterCode))
        {
        }

        public override bool Handle(WillOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)GetWillSoulResponseParameterCode.SoulId];
                string soulName = (string)parameters[(byte)GetWillSoulResponseParameterCode.SoulName];
                bool isActivated = (bool)parameters[(byte)GetWillSoulResponseParameterCode.IsActivated];
                int answerId = (int)parameters[(byte)GetWillSoulResponseParameterCode.AnswerId];
                int[] avatarIds = (int[])parameters[(byte)GetWillSoulResponseParameterCode.AvatarIds];
                VirtualAnswer answer;
                if(ResourceService.Instance.FindAnswer(answerId, out answer))
                {
                    answer.GetWillSoulResponse(returnCode, operationMessage, soulId, soulName, isActivated, answerId, avatarIds);
                    return true;
                }
                else
                {
                    errorMessage = $"Can not find AnswerId:{answerId} for SoulId:{soulId}";
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
