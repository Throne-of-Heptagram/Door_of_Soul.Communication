using Door_of_Soul.Communication.SceneServer.World;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.Protocol.External.World;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.SceneServer.EndPoint.OperationResponseHandler
{
    class DeviceWorldOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public DeviceWorldOperationResponseBroker() : base(typeof(DeviceWorldOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)DeviceWorldOperationResponseParameterCode.DeviceId];
                int worldId = (int)parameters[(byte)DeviceWorldOperationResponseParameterCode.WorldId];
                WorldOperationCode resolvedOperationCode = (WorldOperationCode)parameters[(byte)DeviceWorldOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)DeviceWorldOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)DeviceWorldOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceWorldOperationResponseParameterCode.Parameters];
                TerminalDevice device;
                if (DeviceFactory.Instance.Find(deviceId, out device))
                {
                    WorldOperationResponseApi.SendOperationResponse(device, worldId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters);
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
