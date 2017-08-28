using Door_of_Soul.Communication.Protocol.Hexagram.Shadow;
//using Door_of_Soul.Communication.Protocol.Hexagram.Shadow.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Shadow
{
    public static class ShadowOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, ShadowOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<ShadowEventCode, ShadowOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
