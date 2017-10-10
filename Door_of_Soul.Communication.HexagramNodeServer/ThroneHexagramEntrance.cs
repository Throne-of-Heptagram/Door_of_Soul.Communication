using Door_of_Soul.Communication.Protocol.Hexagram.Throne;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ThroneHexagramEntrance : TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode>
    {
        private object accessAnswerCountLock = new object();
        public int AccessAnswerCount { get; private set; }

        public ThroneHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod)
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
