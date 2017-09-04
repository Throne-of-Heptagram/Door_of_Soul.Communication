using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class TerminalHexagramEntrance<TEventCode, TOperationCode>
    {
        public delegate void SendEventDelegate(TEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);

        public int HexagramEntranceId { get; private set; }

        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }

        public TerminalHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod)
        {
            HexagramEntranceId = hexagramEntranceId;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
        }
    }
}
