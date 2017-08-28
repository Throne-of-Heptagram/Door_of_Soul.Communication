using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Communication.Protocol.Hexagram.Space.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.Protocol.Internal.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Space
{
    public static class SpaceOperationResponseApi
    {
        public static void SendOperationResponse(TerminalHexagramEntrance target, SpaceOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EntranceCommunicationService<SpaceEventCode, SpaceOperationCode>.Instance.SendOperationResponse(target, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public static void WorldOperationResponse(TerminalHexagramEntrance terminal, int endPointId, int deviceId, int worldId, WorldOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)WorldOperationResponseParameterCode.EndPointId, endPointId },
                { (byte)WorldOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)WorldOperationResponseParameterCode.WorldId, worldId },
                { (byte)WorldOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)WorldOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)WorldOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)WorldOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, SpaceOperationCode.WorldOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
        public static void SceneOperationResponse(TerminalHexagramEntrance terminal, int endPointId, int deviceId, int sceneId, SceneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationResponseParameters = new Dictionary<byte, object>
            {
                { (byte)SceneOperationResponseParameterCode.EndPointId, endPointId },
                { (byte)SceneOperationResponseParameterCode.DeviceId, deviceId },
                { (byte)SceneOperationResponseParameterCode.SceneId, sceneId },
                { (byte)SceneOperationResponseParameterCode.OperationCode, operationCode },
                { (byte)SceneOperationResponseParameterCode.OperationReturnCode, operationReturnCode },
                { (byte)SceneOperationResponseParameterCode.OperationMessage, operationMessage },
                { (byte)SceneOperationResponseParameterCode.Parameters, parameters }
            };
            SendOperationResponse(terminal, SpaceOperationCode.SceneOperation, OperationReturnCode.Successiful, "", operationResponseParameters);
        }
    }
}
