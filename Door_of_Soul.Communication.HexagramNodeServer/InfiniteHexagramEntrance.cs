using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class InfiniteHexagramEntrance : TerminalHexagramEntrance<InfiniteEventCode, InfiniteOperationCode, InfiniteInverseOperationCode, InfiniteInverseEventCode>
    {
        public override event Action OnEventDependencyDisappear;

        public InfiniteHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Infinite{base.ToString()}";
        }

        public override void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }
    }
}
