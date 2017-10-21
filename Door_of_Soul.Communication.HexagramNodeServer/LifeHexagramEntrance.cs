using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Life;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class LifeHexagramEntrance : TerminalHexagramEntrance<LifeEventCode, LifeOperationCode, LifeInverseOperationCode, LifeInverseEventCode>
    {
        public override event Action OnEventDependencyDisappear;

        public LifeHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Life{base.ToString()}";
        }

        public override void ReleaseDependency()
        {
            OnEventDependencyDisappear?.Invoke();
        }
    }
}
