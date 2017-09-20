using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using Door_of_Soul.Core.ProxyServer;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.System.OperationResponseHandler
{
    class GetHexagramEntranceAnswerResponseHandler : OperationResponseHandler<VirtualSystem, SystemOperationCode>
    {
        public GetHexagramEntranceAnswerResponseHandler() : base(typeof(GetHexagramEntranceAnswerResponseParameterCode))
        {
        }

        public override bool Handle(VirtualSystem subject, SystemOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)GetHexagramEntranceAnswerResponseParameterCode.AnswerId];
                string answerName = (string)parameters[(byte)GetHexagramEntranceAnswerResponseParameterCode.AnswerName];
                int[] soulIds = (int[])parameters[(byte)GetHexagramEntranceAnswerResponseParameterCode.SoulIds];
                subject.GetHexagramEntranceAnswerResponse(returnCode, operationMessage, answerId, answerName, soulIds);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
