using Door_of_Soul.Communication.SceneServer.EndPoint.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.SceneServer.EndPoint
{
    class EndPointOperationResponseRouter : OperationResponseRouter<EndPointOperationCode>
    {
        public static EndPointOperationResponseRouter Instance { get; private set; } = new EndPointOperationResponseRouter();

        private EndPointOperationResponseRouter() : base("EndPoint")
        {
            OperationTable.Add(EndPointOperationCode.DeviceWorldOperation, new DeviceWorldOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSceneOperation, new DeviceSceneOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.EndPointSystemOperation, new EndPointSystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.EndPointWorldOperation, new EndPointWorldOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.EndPointSceneOperation, new EndPointSceneOperationResponseBroker());
        }
    }
}
