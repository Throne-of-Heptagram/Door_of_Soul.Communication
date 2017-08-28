using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Communication.Protocol.Hexagram.Space.OperationRequestParameter;
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
        public static void WorldOperationRequest(int endPointId, int devicdId, int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationRequestParameterCode.EndPointId, endPointId },
                { (byte)WorldOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)WorldOperationRequestParameterCode.WorldId, worldId },
                { (byte)WorldOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(SpaceOperationCode.WorldOperation, operationRequestParameters);
        }
        public static void SceneOperationRequest(int endPointId, int devicdId, int worldId, int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationRequestParameterCode.EndPointId, endPointId },
                { (byte)SceneOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)SceneOperationRequestParameterCode.WorldId, worldId },
                { (byte)SceneOperationRequestParameterCode.SceneId, sceneId },
                { (byte)SceneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(SpaceOperationCode.SceneOperation, operationRequestParameters);
        }
    }
}
