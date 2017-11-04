using Door_of_Soul.Communication.Protocol.Hexagram.Love;
//using Door_of_Soul.Communication.Protocol.Hexagram.Love.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Love
{
    public static class LoveOperationResponseApi
    {
        public static void SendOperationResponse(LoveHexagramEntrance terminal, LoveOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            terminal.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
