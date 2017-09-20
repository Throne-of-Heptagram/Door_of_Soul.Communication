using Door_of_Soul.Communication.ProxyServer.EndPoint.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint
{
    class EndPointOperationResponseRouter : OperationResponseRouter<EndPointOperationCode>
    {
        public static EndPointOperationResponseRouter Instance { get; private set; } = new EndPointOperationResponseRouter();

        private EndPointOperationResponseRouter() : base("EndPoint")
        {
            OperationTable.Add(EndPointOperationCode.DeviceSystemOperation, new DeviceSystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAnswerOperation, new DeviceAnswerOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSoulOperation, new DeviceSoulOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAvatarOperation, new DeviceAvatarOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.EndPointSystemOperation, new EndPointSystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.EndPointAnswerOperation, new EndPointAnswerOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.EndPointSoulOperation, new EndPointSoulOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.EndPointAvatarOperation, new EndPointAvatarOperationResponseBroker());
        }
    }
}
