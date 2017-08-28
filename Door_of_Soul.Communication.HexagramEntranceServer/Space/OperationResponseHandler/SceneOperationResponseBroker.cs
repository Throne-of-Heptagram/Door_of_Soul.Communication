using Door_of_Soul.Communication.HexagramEntranceServer.Scene;
using Door_of_Soul.Communication.Protocol.Hexagram.Space;
using Door_of_Soul.Communication.Protocol.Hexagram.Space.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Space.OperationResponseHandler
{
    class SceneOperationResponseBroker : OperationResponseHandler<SpaceOperationCode>
    {
        public SceneOperationResponseBroker() : base(typeof(SceneOperationResponseParameterCode))
        {
        }

        public override bool Handle(SpaceOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int endPointId = (int)parameters[(byte)SceneOperationResponseParameterCode.EndPointId];
                int deviceId = (int)parameters[(byte)SceneOperationResponseParameterCode.DeviceId];
                int sceneId = (int)parameters[(byte)SceneOperationResponseParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)SceneOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)SceneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationResponseParameterCode.Parameters];
                TerminalEndPoint endPoint;
                if (CommunicationService.Instance.FindEndPoint(endPointId, out endPoint))
                {
                    SceneOperationResponseApi.SendOperationResponse(endPoint, deviceId, sceneId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters);
                    return true;
                }
                else
                {
                    errorMessage = $"Can not find EndPointId:{endPointId}";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
