using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ShadowHexagramEntrance : TerminalHexagramEntrance<ShadowEventCode, ShadowOperationCode>
    {
        public ShadowHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod)
        {
        }
        public override string ToString()
        {
            return $"Shadow{base.ToString()}";
        }
    }
}
