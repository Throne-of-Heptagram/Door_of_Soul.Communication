using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using Door_of_Soul.Core.HexagramNodeServer;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.EndPoint
{
    public class EndPointThroneOperationRequestRouter : L2SubjectOperationRequestRouter<ThroneHexagramEntrance, int, VirtualThrone, EndPointThroneOperationCode>
    {
        public static EndPointThroneOperationRequestRouter Instance { get; private set; } = new EndPointThroneOperationRequestRouter();

        private EndPointThroneOperationRequestRouter() : base("HexagramEntranceServerEndPointThrone")
        {

        }
    }
}
