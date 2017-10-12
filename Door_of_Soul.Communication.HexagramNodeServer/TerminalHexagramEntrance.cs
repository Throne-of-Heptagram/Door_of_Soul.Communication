﻿using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public abstract class TerminalHexagramEntrance<TEventCode, TOperationCode, TInverseOperationCode, TInverseEventCode>
    {
        public delegate void SendEventDelegate(TEventCode eventCode, Dictionary<byte, object> parameters);
        public delegate void SendOperationResponseDelegate(TOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters);
        public delegate void SendInverseOperationRequestDelegate(TInverseOperationCode inverseOperationCode, Dictionary<byte, object> parameters);

        public int HexagramEntranceId { get; private set; }

        public SendEventDelegate SendEvent { get; private set; }
        public SendOperationResponseDelegate SendOperationResponse { get; private set; }
        public SendInverseOperationRequestDelegate SendInverseOperationRequest { get; private set; }

        public TerminalHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod)
        {
            HexagramEntranceId = hexagramEntranceId;
            SendEvent = sendEventMethod;
            SendOperationResponse = sendOperationResponseMethod;
            SendInverseOperationRequest = sendInverseOperationRequestMethod;
        }
        public override string ToString()
        {
            return $"Entrance Id:{HexagramEntranceId}";
        }
    }
}
