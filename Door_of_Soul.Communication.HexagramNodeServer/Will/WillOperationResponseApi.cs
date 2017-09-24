using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Will
{
    public static class WillOperationResponseApi
    {
        public static void SendOperationResponse(WillHexagramEntrance target, WillOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
