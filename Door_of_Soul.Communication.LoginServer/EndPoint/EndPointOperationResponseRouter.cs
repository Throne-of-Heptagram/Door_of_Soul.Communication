using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.LoginServer.EndPoint.OperationResponseHandler;

namespace Door_of_Soul.Communication.LoginServer.EndPoint
{
    class EndPointOperationResponseRouter : BasicOperationResponseRouter<EndPointOperationCode>
    {
        public static EndPointOperationResponseRouter Instance { get; private set; } = new EndPointOperationResponseRouter();

        private EndPointOperationResponseRouter() : base("EndPoint")
        {
            OperationTable.Add(EndPointOperationCode.DeviceSystemOperation, new DeviceSystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.SystemOperation, new SystemOperationResponseBroker());
        }
    }
}
