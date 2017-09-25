using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public class TerminalEndPoint
    {
        public delegate void SendEventDelegate(EndPointEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public int EndPointId { get; private set; }
        public EndPointType EndPointType { get; private set; }

        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }

        public TerminalEndPoint(int endPointId, EndPointType endPointType, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod)
        {
            EndPointId = endPointId;
            EndPointType = endPointType;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
        }
        public override string ToString()
        {
            return $"EndPoint Id:{EndPointId} Type:{EndPointType}";
        }
    }
}
