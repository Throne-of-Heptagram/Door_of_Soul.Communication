﻿using Door_of_Soul.Communication.Infrastructure.Client.Device;
using Door_of_Soul.Communication.Protocol.External.System;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.Infrastructure.Client.System
{
    public static class SystemOperationRequestApi
    {
        public static void SendOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            DeviceOperationRequestApi.SystemOperationRequest(operationCode, parameters);
        }
    }
}
