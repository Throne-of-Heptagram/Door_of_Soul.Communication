﻿using Door_of_Soul.Communication.Client.System.OperationResponseHandler;
using Door_of_Soul.Communication.Protocol.External.System;
using Door_of_Soul.Core.Client;

namespace Door_of_Soul.Communication.Client.System
{
    class SystemOperationResponseRouter : SubjectOperationResponseRouter<VirtualSystem, SystemOperationCode>
    {
        public static SystemOperationResponseRouter Instance { get; private set; } = new SystemOperationResponseRouter();

        private SystemOperationResponseRouter() : base("ClientSystem")
        {
            OperationTable.Add(SystemOperationCode.Register, new RegisterResponseHandler());
            OperationTable.Add(SystemOperationCode.Login, new LoginResponseHandler());
        }
    }
}
