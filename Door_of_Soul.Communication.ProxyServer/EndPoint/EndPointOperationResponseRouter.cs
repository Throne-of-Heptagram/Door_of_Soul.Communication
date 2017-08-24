﻿using Door_of_Soul.Communication.ProxyServer.EndPoint.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;

namespace Door_of_Soul.Communication.ProxyServer.EndPoint
{
    class EndPointOperationResponseRouter : OperationResponseRouter<Core.Internal.EndPoint, Core.Internal.EndPoint, EndPointOperationCode>
    {
        public static EndPointOperationResponseRouter Instance { get; private set; } = new EndPointOperationResponseRouter();

        private EndPointOperationResponseRouter()
        {
            OperationTable.Add(EndPointOperationCode.SystemOperation, new SystemOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.AnswerOperation, new AnswerOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.SoulOperation, new SoulOperationResponseBroker());
            OperationTable.Add(EndPointOperationCode.AvatarOperation, new AvatarOperationResponseBroker());
        }
    }
}