using Door_of_Soul.Communication.SceneServer.Device;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.World
{
    public static class WorldOperationResponseApi
    {
        public static void SendOperationResponse(TerminalDevice terminal, int worldId, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            DeviceOperationResponseApi.WorldOperationResponse(terminal, worldId, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
