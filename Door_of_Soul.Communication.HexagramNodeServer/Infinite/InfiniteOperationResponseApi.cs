using Door_of_Soul.Communication.Protocol.Hexagram.Infinite;
//using Door_of_Soul.Communication.Protocol.Hexagram.Infinite.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Infinite
{
    public static class InfiniteOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, InfiniteOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<InfiniteEventCode, InfiniteOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
