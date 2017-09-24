using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.TrinityServer.Device;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.Soul
{
    public static class SoulOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, int soulId, SoulOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.SoulOperationResponse(terminal, soulId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
