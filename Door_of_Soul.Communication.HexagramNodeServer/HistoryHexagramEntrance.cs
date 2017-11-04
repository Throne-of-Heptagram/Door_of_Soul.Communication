using System;
using Door_of_Soul.Communication.Protocol.Hexagram.History;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class HistoryHexagramEntrance : TerminalHexagramEntrance<HistoryEventCode, HistoryOperationCode, HistoryInverseOperationCode, HistoryInverseEventCode>
    {
        public HistoryHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"History{base.ToString()}";
        }
    }
}
