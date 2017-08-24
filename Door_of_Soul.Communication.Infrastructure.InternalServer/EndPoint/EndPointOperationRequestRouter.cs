using Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.Infrastructure.InternalServer.EndPoint
{
    class EndPointOperationRequestRouter : OperationRequestRouter<Core.Internal.EndPoint, Core.Internal.EndPoint, EndPointOperationCode>
    {
        public static EndPointOperationRequestRouter Instance { get; private set; } = new EndPointOperationRequestRouter();

        private EndPointOperationRequestRouter()
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
