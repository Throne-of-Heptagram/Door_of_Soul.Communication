using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.Protocol.Internal.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Space
{
    public static class SpaceOperationRequestApi
    {
        public static void SendOperationRequest(SpaceOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            SpaceCommunicationService.Instance.SendOperation(operationCode, parameters);
        }
    }
}
