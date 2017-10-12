using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.InverseOperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne
{
    public static class ThroneInverseOperationRequestApi
    {
        public static void SendOperationRequest(ThroneHexagramEntrance target, ThroneInverseOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            target.SendInverseOperationRequest(operationCode, parameters);
        }

        public static void AssignAnswer(ThroneHexagramEntrance terminal, int answerId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)AssignAnswerRequestParameterCode.AnswerId, answerId }
            };
            SendOperationRequest(terminal, ThroneInverseOperationCode.AssignAnswer, operationRequestParameters);
        }
    }
}
