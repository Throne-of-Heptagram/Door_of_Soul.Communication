using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System.OperationRequestHandler
{
    class GetAnswerTrinityServerRequestHandler : SubjectOperationRequestHandler<TerminalEndPoint, VirtualSystem, SystemOperationCode>
    {
        public GetAnswerTrinityServerRequestHandler() : base(typeof(GetAnswerTrinityServerRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint terminal, VirtualSystem target, SystemOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendEndPointOperationResponse(terminal, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalEndPoint terminal, VirtualSystem requester, SystemOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int answerId = (int)parameters[(byte)GetAnswerTrinityServerRequestParameterCode.AnswerId];
                OperationReturnCode returnCode = requester.GetAnswerTrinityServer(terminal.EndPointId, answerId, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    SendResponse(terminal, requester, operationCode, returnCode, errorMessage, new Dictionary<byte, object>());
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
