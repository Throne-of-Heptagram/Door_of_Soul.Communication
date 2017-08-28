using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint
{
    class EndPointOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, EndPointOperationCode>
    {
        public static EndPointOperationRequestRouter Instance { get; private set; } = new EndPointOperationRequestRouter();

        private EndPointOperationRequestRouter() : base("EndPoint")
        {
            OperationTable.Add(EndPointOperationCode.SystemOperation, new SystemOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.AnswerOperation, new AnswerOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.SoulOperation, new SoulOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.AvatarOperation, new AvatarOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.WorldOperation, new WorldOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.SceneOperation, new SceneOperationRequestBroker());
        }
    }
}
