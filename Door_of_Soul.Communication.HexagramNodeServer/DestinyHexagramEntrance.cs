using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class DestinyHexagramEntrance : TerminalHexagramEntrance<DestinyEventCode, DestinyOperationCode, DestinyInverseOperationCode, DestinyInverseEventCode>
    {
        public DestinyHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }
        public override string ToString()
        {
            return $"Destiny{base.ToString()}";
        }
    }
}
