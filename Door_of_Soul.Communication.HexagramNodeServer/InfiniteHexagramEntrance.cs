using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class InfiniteHexagramEntrance : TerminalHexagramEntrance<InfiniteEventCode, InfiniteOperationCode>
    {
        public InfiniteHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod)
        {
        }
    }
}
