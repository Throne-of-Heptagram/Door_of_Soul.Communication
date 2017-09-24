using Door_of_Soul.Communication.ObserverServer.EndPoint.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.ObserverServer.EndPoint
{
    class EndPointOperationResponseRouter : OperationResponseRouter<EndPointOperationCode>
    {
        public static EndPointOperationResponseRouter Instance { get; private set; } = new EndPointOperationResponseRouter();

        private EndPointOperationResponseRouter() : base("EndPoint")
        {
            OperationTable.Add(EndPointOperationCode.DeviceWorldOperation, new DeviceWorldOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSceneOperation, new DeviceSceneOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.SystemOperation, new SystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.WorldOperation, new WorldOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.SceneOperation, new SceneOperationResponseBroker());
        }
    }
}
