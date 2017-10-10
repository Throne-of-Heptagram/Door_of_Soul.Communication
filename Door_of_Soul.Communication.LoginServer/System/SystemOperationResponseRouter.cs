using Door_of_Soul.Communication.LoginServer.System.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Core.LoginServer;

namespace Door_of_Soul.Communication.LoginServer.System
{
    class SystemOperationResponseRouter : SubjectOperationResponseRouter<VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationResponseRouter Instance { get; private set; } = new SystemOperationResponseRouter();

        private SystemOperationResponseRouter() : base("LoginServerSystem")
        {
            OperationTable.Add(SystemOperationCode.GetAnswerTrinityServer, new GetAnswerTrinityServerResponseHandler());
        }
    }
}
