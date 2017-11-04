using System;
using Door_of_Soul.Communication.Protocol.Hexagram.Knowledge;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class KnowledgeHexagramEntrance : TerminalHexagramEntrance<KnowledgeEventCode, KnowledgeOperationCode, KnowledgeInverseOperationCode, KnowledgeInverseEventCode>
    {
        public KnowledgeHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod, SendInverseOperationRequestDelegate sendInverseOperationRequestMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod, sendInverseOperationRequestMethod)
        {
        }

        public override string ToString()
        {
            return $"Knowledge{base.ToString()}";
        }
    }
}
