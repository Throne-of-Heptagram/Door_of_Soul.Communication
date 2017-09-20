using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.OperationRequestParameter;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System.OperationRequestHandler
{
    class GetHexagramEntranceAnswerRequestHandler : OperationRequestHandler<TerminalEndPoint, VirtualSystem, SystemOperationCode>
    {
        public GetHexagramEntranceAnswerRequestHandler() : base(typeof(GetHexagramEntranceAnswerRequestParameterCode))
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
                int answerId = (int)parameters[(byte)GetHexagramEntranceAnswerRequestParameterCode.AnswerId];
                OperationReturnCode returnCode = requester.GetThroneAnswer(terminal.EndPointId, answerId, out errorMessage);
                return returnCode == OperationReturnCode.Successiful;
            }
            else
            {
                return false;
            }
        }
    }
}
