using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.EndPoint
{
    class EndPointThroneOperationResponseRouter : SubjectOperationResponseRouter<TerminalEndPoint, EndPointThroneOperationCode>
    {
        public static EndPointThroneOperationResponseRouter Instance { get; private set; } = new EndPointThroneOperationResponseRouter();

        private EndPointThroneOperationResponseRouter() : base("HexagramEntranceServerEndPointThrone")
        {

        }
    }
}
