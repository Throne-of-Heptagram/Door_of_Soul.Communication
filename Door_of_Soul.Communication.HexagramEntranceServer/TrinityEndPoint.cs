namespace Door_of_Soul.Communication.HexagramEntranceServer
{
    public class TrinityEndPoint : TerminalEndPoint
    {
        private object accessAnswerCountLock = new object();

        internal TrinityEndPoint(int endPointId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(endPointId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public int AccessAnswerCount { get; private set; }

        public override string ToString()
        {
            return $"{base.ToString()} Type: Trinity";
        }

        public void IncreaseAccessAnswerCount()
        {
            lock (accessAnswerCountLock)
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
