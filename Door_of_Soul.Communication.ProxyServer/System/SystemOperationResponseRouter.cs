using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.ProxyServer.System.OperationResponseHandler;
using Door_of_Soul.Core.ProxyServer;

namespace Door_of_Soul.Communication.ProxyServer.System
{
    class SystemOperationResponseRouter : OperationResponseRouter<VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationResponseRouter Instance { get; private set; } = new SystemOperationResponseRouter();

        private SystemOperationResponseRouter()
        {
            OperationTable.Add(SystemOperationCode.GetHexagramEntranceAnswer, new GetHexagramEntranceAnswerResponseHandler());
        }
    }
}
