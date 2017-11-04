using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Element;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class ElementHexagramEntrance : TerminalHexagramEntrance<ElementEventCode, ElementOperationCode, ElementInverseOperationCode, ElementInverseEventCode>
    {
        public ElementHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Element{base.ToString()}";
        }
    }
}
