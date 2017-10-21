using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Love;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class LoveHexagramEntrance : TerminalHexagramEntrance<LoveEventCode, LoveOperationCode, LoveInverseOperationCode, LoveInverseEventCode>
    {
        public override event Action OnEventDependencyDisappear;

        public LoveHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Love{base.ToString()}";
        }

        public override void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }
    }
}
