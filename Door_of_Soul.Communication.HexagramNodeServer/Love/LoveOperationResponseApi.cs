using Door_of_Soul.Communication.Protocol.Hexagram.Love;
//using Door_of_Soul.Communication.Protocol.Hexagram.Love.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public static class LoveOperationResponseApi
    {
        public static void SendOperationResponse(LoveHexagramEntrance target, LoveOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
