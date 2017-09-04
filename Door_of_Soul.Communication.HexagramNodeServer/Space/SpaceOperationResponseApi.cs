using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public static class SpaceOperationResponseApi
    {
        public static void SendOperationResponse(SpaceHexagramEntrance target, SpaceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
