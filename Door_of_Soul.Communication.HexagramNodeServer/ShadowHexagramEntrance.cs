using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ShadowHexagramEntrance : TerminalHexagramEntrance<ShadowEventCode, ShadowOperationCode, ShadowInverseOperationCode, ShadowInverseEventCode>
    {
        public ShadowHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Shadow{base.ToString()}";
        }
    }
}
