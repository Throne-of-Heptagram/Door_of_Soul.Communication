using Door_of_Soul.Communication.Protocol.Hexagram.Life;
//using Door_of_Soul.Communication.Protocol.Hexagram.Life.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Life
{
    public static class LifeOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, LifeOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<LifeEventCode, LifeOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }
    }
}
