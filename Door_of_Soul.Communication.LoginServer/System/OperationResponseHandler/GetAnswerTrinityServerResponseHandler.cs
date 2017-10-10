using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationResponseParameter;
using Door_of_Soul.Core.LoginServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.LoginServer.System.OperationResponseHandler
{
    class GetAnswerTrinityServerResponseHandler : SubjectOperationResponseHandler<VirtualSystem, SystemOperationCode>
    {
        public GetAnswerTrinityServerResponseHandler() : base(typeof(GetAnswerTrinityServerResponseParameterCode))
        {
        }

        public override bool Handle(VirtualSystem subject, SystemOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(subject, operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                string trinityServerAddress = (string)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.TrinityServerAddress];
                int trinityServerPort = (int)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.TrinityServerPort];
                string trinityServerApplicationName = (string)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.TrinityServerApplicationName];
                int answerId = (int)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.AnswerId];
                string answerAccessToken = (string)parameters[(byte)GetAnswerTrinityServerResponseParameterCode.AnswerAccessToken];
                subject.GetAnswerTrinityServerResponse(returnCode, operationMessage, trinityServerAddress, trinityServerPort, trinityServerApplicationName, answerId, answerAccessToken);
                return true;
            }
            else
            {
                subject.GetAnswerTrinityServerResponse(returnCode, operationMessage, default(string), default(int), default(string), default(int), default(string));
                return false;
            }
        }
    }
}
