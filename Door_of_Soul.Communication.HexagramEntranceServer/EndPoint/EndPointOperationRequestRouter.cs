using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint
{
    class EndPointOperationRequestRouter : OperationRequestRouter<TerminalEndPoint, EndPointOperationCode>
    {
        public static EndPointOperationRequestRouter Instance { get; private set; } = new EndPointOperationRequestRouter();

        private EndPointOperationRequestRouter() : base("EndPoint")
        {
            OperationTable.Add(EndPointOperationCode.DeviceSystemOperation, new DeviceSystemOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAnswerOperation, new DeviceAnswerOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSoulOperation, new DeviceSoulOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAvatarOperation, new DeviceAvatarOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceWorldOperation, new DeviceWorldOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSceneOperation, new DeviceSceneOperationRequestBroker());

            OperationTable.Add(EndPointOperationCode.EndPointSystemOperation, new EndPointSystemOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.EndPointAnswerOperation, new EndPointAnswerOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.EndPointSoulOperation, new EndPointSoulOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.EndPointAvatarOperation, new EndPointAvatarOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.EndPointWorldOperation, new EndPointWorldOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.EndPointSceneOperation, new EndPointSceneOperationRequestBroker());
        }
    }
}
