using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using System;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ThroneHexagramEntrance : TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode, ThroneInverseOperationCode, ThroneInverseEventCode>
    {
        public event Action OnDisconnected;
        public override event Action OnEventDependencyDisappear;

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
        public void Disconnect()
        {
            OnDisconnected?.Invoke();
            ReleaseDependency();
        }

        public override void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }
    }
}
