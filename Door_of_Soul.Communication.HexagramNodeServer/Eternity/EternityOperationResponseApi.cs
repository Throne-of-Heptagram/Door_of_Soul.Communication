using Door_of_Soul.Communication.Protocol.Hexagram.Eternity;
//using Door_of_Soul.Communication.Protocol.Hexagram.Eternity.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Eternity
{
    public static class EternityOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, EternityOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<EternityEventCode, EternityOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
