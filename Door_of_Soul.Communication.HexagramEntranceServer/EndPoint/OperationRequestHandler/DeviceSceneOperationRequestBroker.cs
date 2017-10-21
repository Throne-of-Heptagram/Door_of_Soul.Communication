using Door_of_Soul.Communication.HexagramEntranceServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class DeviceSceneOperationRequestBroker : BasicOperationRequestHandler<TerminalEndPoint>
    {
        public DeviceSceneOperationRequestBroker() : base(typeof(DeviceSceneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(target, EndPointOperationCode.DeviceSceneOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalEndPoint terminal, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int deviceId = (int)parameters[(byte)DeviceSceneOperationRequestParameterCode.DeviceId];
                int sceneId = (int)parameters[(byte)DeviceSceneOperationRequestParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)DeviceSceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceSceneOperationRequestParameterCode.Parameters];
                VirtualScene scene;
                if (ResourceService.Instance.FindScene(sceneId, out scene))
                {
                    returnCode = SceneOperationRequestRouter.Instance.Route(terminal, deviceId, scene, resolvedOperationCode, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find SceneId:{sceneId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
