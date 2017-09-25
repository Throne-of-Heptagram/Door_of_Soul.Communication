using Door_of_Soul.Communication.Protocol.Hexagram.Space;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class SpaceHexagramEntrance : TerminalHexagramEntrance<SpaceEventCode, SpaceOperationCode>
    {
        public SpaceHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod)
        {
        }
        public override string ToString()
        {
            return $"Space{base.ToString()}";
        }
    }
}
