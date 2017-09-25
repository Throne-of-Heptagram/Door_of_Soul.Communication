using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;

namespace Door_of_Soul.Communication.HexagramNodeServer
{
    public class EternityHexagramEntrance : TerminalHexagramEntrance<EternityEventCode, EternityOperationCode>
    {
        public EternityHexagramEntrance(int hexagramEntranceId, SendEventDelegate sendEventMethod, SendOperationResponseDelegate sendOperationResponseMethod) : base(hexagramEntranceId, sendEventMethod, sendOperationResponseMethod)
        {
        }
        public override string ToString()
        {
            return $"Eternity{base.ToString()}";
        }
    }
}
