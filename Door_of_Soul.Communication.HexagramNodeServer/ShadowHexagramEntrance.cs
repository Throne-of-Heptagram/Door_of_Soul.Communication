using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ShadowHexagramEntrance : TerminalHexagramEntrance<ShadowEventCode, ShadowOperationCode, ShadowInverseOperationCode, ShadowInverseEventCode>
    {
        public override event Action OnEventDependencyDisappear;

        public ShadowHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }

        public override string ToString()
        {
            return $"Shadow{base.ToString()}";
        }
    }
}
