﻿using Door_of_Soul.Communication.Protocol.External.Soul;

namespace Door_of_Soul.Communication.Infrastructure.ExternalServer.Soul
{
    class SoulOperationRequestRouter : OperationRequestRouter<Core.Soul, SoulOperationCode>
    {
        public static SoulOperationRequestRouter Instance { get; private set; } = new SoulOperationRequestRouter();

        private SoulOperationRequestRouter()
        {

        }
    }
}
