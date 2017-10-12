using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ThroneHexagramEntrance : TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode, ThroneInverseOperationCode, ThroneInverseEventCode>
    {
        private object accessAnswerCountLock = new object();
        public int AccessAnswerCount { get; private set; }

        public ThroneHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }
        public override string ToString()
        {
            return $"Throne{base.ToString()}";
        }

        public void IncreaseAccessAnswerCount()
        {
            lock(accessAnswerCountLock)
            {
                AccessAnswerCount++;
            }
        }
        public void DecreaseAccessAnswerCount()
        {
            lock (accessAnswerCountLock)
            {
                AccessAnswerCount--;
            }
        }
    }
}
