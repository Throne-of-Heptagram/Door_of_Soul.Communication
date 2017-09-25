using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class WillHexagramEntrance : TerminalHexagramEntrance<WillEventCode, WillOperationCode>
    {
        public WillHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod)
        {
        }
        public override string ToString()
        {
            return $"Will{base.ToString()}";
        }
    }
}
