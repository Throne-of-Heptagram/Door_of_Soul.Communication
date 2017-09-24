using Door_of_Soul.Communication.ObserverServer.Scene;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.Scene;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.ObserverServer.EndPoint.OperationResponseHandler
{
    class DeviceSceneOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public DeviceSceneOperationResponseBroker() : base(typeof(DeviceSceneOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)DeviceSceneOperationResponseParameterCode.DeviceId];
                int sceneId = (int)parameters[(byte)DeviceSceneOperationResponseParameterCode.SceneId];
                SceneOperationCode resolvedOperationCode = (SceneOperationCode)parameters[(byte)DeviceSceneOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)DeviceSceneOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)DeviceSceneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceSceneOperationResponseParameterCode.Parameters];
                TerminalDevice device;
                if (DeviceFactory.Instance.Find(deviceId, out device))
                {
                    SceneOperationResponseApi.SendOperationResponse(device, sceneId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters);
                    return true;
                }
                else
                {
                    errorMessage = $"Can not find DeviceId:{deviceId}";
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
