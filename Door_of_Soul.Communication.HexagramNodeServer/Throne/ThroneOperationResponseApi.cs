using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
//using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, ThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<ThroneEventCode, ThroneOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
