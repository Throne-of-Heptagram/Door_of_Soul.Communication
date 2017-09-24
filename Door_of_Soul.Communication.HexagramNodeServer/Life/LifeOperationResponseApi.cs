using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public static class LifeOperationResponseApi
    {
        public static void SendOperationResponse(LifeHexagramEntrance target, LifeOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
