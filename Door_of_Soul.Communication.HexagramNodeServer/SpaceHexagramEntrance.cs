using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class SpaceHexagramEntrance : TerminalHexagramEntrance<SpaceEventCode, SpaceOperationCode, SpaceInverseOperationCode, SpaceInverseEventCode>
    {
        public SpaceHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }
        public override string ToString()
        {
            return $"Space{base.ToString()}";
        }
    }
}
