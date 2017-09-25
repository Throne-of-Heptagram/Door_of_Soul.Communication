using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class LoveHexagramEntrance : TerminalHexagramEntrance<LoveEventCode, LoveOperationCode>
    {
        public LoveHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod)
        {
        }
        public override string ToString()
        {
            return $"Love{base.ToString()}";
        }
    }
}
