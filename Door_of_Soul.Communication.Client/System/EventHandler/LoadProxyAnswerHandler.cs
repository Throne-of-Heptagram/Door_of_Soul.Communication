using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Communication.Protocol.External.System.EventParameter;
using Door_of_Soul.Core.Client;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.System.EventHandler
{
    class LoadProxyAnswerHandler : EventHandler<VirtualSystem, SystemEventCode>
    {
        public LoadProxyAnswerHandler() : base(typeof(LoadProxyAnswerParameterCode))
        {
        }

        public override bool Handle(VirtualSystem subject, SystemEventCode eventCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, eventCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)LoadProxyAnswerParameterCode.AnswerId];
                string answerName = (string)parameters[(byte)LoadProxyAnswerParameterCode.AnswerName];
                int[] soulIds = (int[])parameters[(byte)LoadProxyAnswerParameterCode.SoulIds];
                subject.LoadProxyAnswer(answerId, answerName, soulIds);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
