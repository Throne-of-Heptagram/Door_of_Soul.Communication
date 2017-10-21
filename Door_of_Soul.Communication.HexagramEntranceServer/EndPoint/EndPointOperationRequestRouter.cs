using Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint
{
    class EndPointOperationRequestRouter : BasicOperationRequestRouter<TerminalEndPoint, EndPointOperationCode>
    {
        public static EndPointOperationRequestRouter Instance { get; private set; } = new EndPointOperationRequestRouter();

        private EndPointOperationRequestRouter() : base("HexagramEntranceServerEndPoint")
        {
            OperationTable.Add(EndPointOperationCode.DeviceSystemOperation, new DeviceSystemOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAnswerOperation, new DeviceAnswerOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSoulOperation, new DeviceSoulOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAvatarOperation, new DeviceAvatarOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceWorldOperation, new DeviceWorldOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSceneOperation, new DeviceSceneOperationRequestBroker());

            OperationTable.Add(EndPointOperationCode.SystemOperation, new SystemOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.AnswerOperation, new AnswerOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.SoulOperation, new SoulOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.AvatarOperation, new AvatarOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.WorldOperation, new WorldOperationRequestBroker());
            OperationTable.Add(EndPointOperationCode.SceneOperation, new SceneOperationRequestBroker());
        }
    }
}
