using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Communication.Protocol.Internal.System;
using Door_of_Soul.Communication.Protocol.Internal.World;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.EndPoint
{
    public static class EndPointOperationRequestApi
    {
        public static void SendOperationRequest(EndPointOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            CommunicationService.Instance.SendOperation(operationCode, parameters);
        }
        public static void DeviceWorldOperationRequest(int devicdId, int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceWorldOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)DeviceWorldOperationRequestParameterCode.WorldId, worldId },
                { (byte)DeviceWorldOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceWorldOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.DeviceWorldOperation, operationRequestParameters);
        }
        public static void DeviceSceneOperationRequest(int devicdId, int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceSceneOperationRequestParameterCode.DeviceId, devicdId },
                { (byte)DeviceSceneOperationRequestParameterCode.SceneId, sceneId },
                { (byte)DeviceSceneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceSceneOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.DeviceSceneOperation, operationRequestParameters);
        }
        public static void EndPointSystemOperationRequest(SystemOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointSystemOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointSystemOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.EndPointWorldOperation, operationRequestParameters);
        }
        public static void EndPointWorldOperationRequest(int worldId, WorldOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointWorldOperationRequestParameterCode.WorldId, worldId },
                { (byte)EndPointWorldOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointWorldOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.EndPointWorldOperation, operationRequestParameters);
        }
        public static void EndPointSceneOperationRequest(int sceneId, SceneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointSceneOperationRequestParameterCode.SceneId, sceneId },
                { (byte)EndPointSceneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointSceneOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(EndPointOperationCode.EndPointSceneOperation, operationRequestParameters);
        }
    }
}
