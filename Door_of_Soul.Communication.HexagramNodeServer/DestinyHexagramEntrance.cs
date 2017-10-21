using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class DestinyHexagramEntrance : TerminalHexagramEntrance<DestinyEventCode, DestinyOperationCode, DestinyInverseOperationCode, DestinyInverseEventCode>
    {
        public override event Action OnEventDependencyDisappear;

        public DestinyHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Destiny{base.ToString()}";
        }

        public override void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }
    }
}
