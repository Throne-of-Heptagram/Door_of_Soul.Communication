using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.System.InverseOperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.System
{
    public static class SystemInverseOperationRequestApi
    {
        public static void SendOperationRequest(TerminalEndPoint terminal, SystemInverseOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            EndPointInverseOperationRequestApi.SystemInverseOperationRequest(terminal, operationCode, parameters);
        }

        public static void ThroneAssignAnswer(TerminalEndPoint terminal, int answerId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)ThroneAssignAnswerRequestParameterCode.AnswerId, answerId }
            };
            SendOperationRequest(terminal, SystemInverseOperationCode.ThroneAssignAnswer, operationRequestParameters);
        }
    }
}
