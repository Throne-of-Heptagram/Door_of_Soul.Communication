using Door_of_Soul.Communication.Protocol.Hexagram.Life;
using Door_of_Soul.Communication.Protocol.Hexagram.Life.OperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Life
{
    public static class LifeOperationRequestApi
    {
        public static void SendOperationRequest(LifeOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            LifeCommunicationService.Instance.SendOperation(operationCode, parameters);
        }

        public static void GetLifeAvatar(int avatarId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetLifeAvatarRequestParameterCode.AvatarId, avatarId }
            };
            SendOperationRequest(LifeOperationCode.GetLifeAvatar, operationRequestParameters);
        }
    }
}
