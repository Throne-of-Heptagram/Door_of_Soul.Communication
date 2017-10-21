using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System.OperationRequestHandler
{
    class GetAnswerTrinityServerRequestHandler : SubjectOperationRequestHandler<TerminalEndPoint, VirtualSystem>
    {
        public GetAnswerTrinityServerRequestHandler() : base(typeof(GetAnswerTrinityServerRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint terminal, VirtualSystem target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            SystemOperationResponseApi.SendEndPointOperationResponse(terminal, SystemOperationCode.GetAnswerTrinityServer, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalEndPoint terminal, VirtualSystem requester, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, requester, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int answerId = (int)parameters[(byte)GetAnswerTrinityServerRequestParameterCode.AnswerId];
                returnCode = requester.GetAnswerTrinityServer(terminal.EndPointId, answerId, out errorMessage);
                if (returnCode != OperationReturnCode.Successiful)
                {
                    SendResponse(terminal, requester, returnCode, errorMessage, new Dictionary<byte, object>());
                }
            }
            return returnCode;
        }
    }
}
