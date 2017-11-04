using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EternityHexagramEntrance : TerminalHexagramEntrance<EternityEventCode, EternityOperationCode, EternityInverseOperationCode, EternityInverseEventCode>
    {
        public EternityHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Eternity{base.ToString()}";
        }
    }
}
