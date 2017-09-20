using Door_of_Soul.Communication.Protocol.Hexagram.Will;
using Door_of_Soul.Communication.Protocol.Hexagram.Will.OperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Will
{
    public static class WillOperationRequestApi
    {
        public static void SendOperationRequest(WillOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            WillCommunicationService.Instance.SendOperation(operationCode, parameters);
        }

        public static void GetWillSoul(int soulId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetWillSoulRequestParameterCode.SoulId, soulId }
            };
            SendOperationRequest(WillOperationCode.GetWillSoul, operationRequestParameters);
        }
    }
}
