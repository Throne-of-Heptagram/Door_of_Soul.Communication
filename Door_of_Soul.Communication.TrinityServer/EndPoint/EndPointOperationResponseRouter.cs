using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.TrinityServer.EndPoint.OperationResponseHandler;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint
{
    class EndPointOperationResponseRouter : BasicOperationResponseRouter<EndPointOperationCode>
    {
        public static EndPointOperationResponseRouter Instance { get; private set; } = new EndPointOperationResponseRouter();

        private EndPointOperationResponseRouter() : base("EndPoint")
        {
            OperationTable.Add(EndPointOperationCode.DeviceSystemOperation, new DeviceSystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAnswerOperation, new DeviceAnswerOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceSoulOperation, new DeviceSoulOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.DeviceAvatarOperation, new DeviceAvatarOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.SystemOperation, new SystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.AnswerOperation, new AnswerOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.SoulOperation, new SoulOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.AvatarOperation, new AvatarOperationResponseBroker());
        }
    }
}
