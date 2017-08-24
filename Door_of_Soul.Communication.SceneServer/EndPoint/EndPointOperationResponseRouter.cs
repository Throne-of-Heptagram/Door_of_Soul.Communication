using Door_of_Soul.Communication.SceneServer.EndPoint.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.SceneServer.EndPoint
{
    class EndPointOperationResponseRouter : OperationResponseRouter<Core.Internal.EndPoint, Core.Internal.EndPoint, EndPointOperationCode>
    {
        public static EndPointOperationResponseRouter Instance { get; private set; } = new EndPointOperationResponseRouter();

        private EndPointOperationResponseRouter()
        {
            OperationTable.Add(EndPointOperationCode.SystemOperation, new SystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.WorldOperation, new WorldOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.SceneOperation, new SceneOperationResponseBroker());
        }
    }
}
