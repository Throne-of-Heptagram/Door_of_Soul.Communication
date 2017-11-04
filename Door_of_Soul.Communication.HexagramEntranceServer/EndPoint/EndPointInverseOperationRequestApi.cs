using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.InverseOperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint
{
    public static class EndPointInverseOperationRequestApi
    {
        public static void SendOperationRequest(TerminalEndPoint terminal, EndPointInverseOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            terminal.SendInverseOperationRequest(operationCode, parameters);
        }

        public static void SystemInverseOperationRequest(TerminalEndPoint terminal, SystemInverseOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SystemInverseOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SystemInverseOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(terminal, EndPointInverseOperationCode.SystemInverseOperation, operationRequestParameters);
        }
    }
}
