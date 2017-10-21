using Door_of_Soul.Communication.HexagramEntranceServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationRequestParameter;
using Door_of_Soul.Communication.Protocol.Internal.Scene;
using Door_of_Soul.Core.HexagramEntranceServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.EndPoint.OperationRequestHandler
{
    class SceneOperationRequestBroker : BasicOperationRequestHandler<TerminalEndPoint>
    {
        public SceneOperationRequestBroker() : base(typeof(SceneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalEndPoint target, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            EndPointOperationResponseApi.SendOperationResponse(target, EndPointOperationCode.SceneOperation, operationReturnCode, operationMessage, parameters);
        }

        public override OperationReturnCode Handle(TerminalEndPoint terminal, Dictionary<byte, object> parameters, out string errorMessage)
        {
            OperationReturnCode returnCode = base.Handle(terminal, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int sceneId = (int)parameters[(byte)SceneOperationRequestParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)SceneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)SceneOperationRequestParameterCode.Parameters];
                VirtualScene scene;
                if (ResourceService.Instance.FindScene(sceneId, out scene))
                {
                    returnCode = SceneOperationRequestRouter.Instance.Route(terminal, scene, resolvedOperationCode, resolvedParameters, out errorMessage);
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
