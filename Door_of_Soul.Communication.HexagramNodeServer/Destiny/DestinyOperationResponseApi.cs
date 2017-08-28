using Door_of_Soul.Communication.Protocol.Hexagram.Destiny;
//using Door_of_Soul.Communication.Protocol.Hexagram.Destiny.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Destiny
{
    public static class DestinyOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, DestinyOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<DestinyEventCode, DestinyOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
