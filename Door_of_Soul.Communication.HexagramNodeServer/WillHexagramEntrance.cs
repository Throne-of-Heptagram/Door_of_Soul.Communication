using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Will;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class WillHexagramEntrance : TerminalHexagramEntrance<WillEventCode, WillOperationCode, WillInverseOperationCode, WillInverseEventCode>
    {
        public WillHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Will{base.ToString()}";
        }
    }
}
