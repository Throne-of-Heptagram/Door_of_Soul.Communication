using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    public static class ThroneOperationRequestApi
    {
        public static void SendOperationRequest(ThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            ThroneCommunicationService.Instance.SendOperation(operationCode, parameters);
        }

        public static void GetThroneAnswer(int answerId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetThroneAnswerRequestParameterCode.AnswerId, answerId }
            };
            SendOperationRequest(ThroneOperationCode.GetThroneAnswer, operationRequestParameters);
        }
    }
}
