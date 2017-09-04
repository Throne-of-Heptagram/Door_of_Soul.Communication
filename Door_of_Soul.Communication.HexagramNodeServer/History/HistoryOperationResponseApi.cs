using Door_of_Soul.Communication.Protocol.Hexagram.History;
//using Door_of_Soul.Communication.Protocol.Hexagram.History.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.History
{
    public static class HistoryOperationResponseApi
    {
        public static void SendOperationResponse(HistoryHexagramEntrance target, HistoryOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            target.SendOperationResponse(operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
