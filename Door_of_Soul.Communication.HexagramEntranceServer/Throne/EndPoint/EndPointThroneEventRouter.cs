using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.EndPoint
{
    class EndPointThroneEventRouter : SubjectEventRouter<TerminalEndPoint, EndPointThroneEventCode>
    {
        public static EndPointThroneEventRouter Instance { get; private set; } = new EndPointThroneEventRouter();

        private EndPointThroneEventRouter() : base("HexagramEntranceServerEndPointThrone")
        {

        }
    }
}
