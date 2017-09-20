using Door_of_Soul.Communication.Protocol.External.Answer;
using Door_of_Soul.Communication.Protocol.External.Answer.EventParameter;
using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.Answer.EventHandler
{
    class LoadProxySoulHandler : EventHandler<VirtualAnswer, AnswerEventCode>
    {
        public LoadProxySoulHandler() : base(typeof(LoadProxySoulParameterCode))
        {
        }

        public override bool Handle(VirtualAnswer subject, AnswerEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                int soulId = (int)parameters[(byte)LoadProxySoulParameterCode.SoulId];
                string soulName = (string)parameters[(byte)LoadProxySoulParameterCode.SoulName];
                bool isActivated = (bool)parameters[(byte)LoadProxySoulParameterCode.IsActivated];
                int answerId = (int)parameters[(byte)LoadProxySoulParameterCode.AnswerId];
                int[] avatarIds = (int[])parameters[(byte)LoadProxySoulParameterCode.AvatarIds];
                subject.LoadProxySoul(soulId, soulName, isActivated, answerId, avatarIds);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
