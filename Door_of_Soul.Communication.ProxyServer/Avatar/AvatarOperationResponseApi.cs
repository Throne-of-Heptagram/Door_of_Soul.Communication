﻿using Door_of_Soul.Communication.ProxyServer.Device;
using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ProxyServer.Avatar
{
    public static class AvatarOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, Core.Avatar target, AvatarOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.AvatarOperationResponse(terminal, target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}