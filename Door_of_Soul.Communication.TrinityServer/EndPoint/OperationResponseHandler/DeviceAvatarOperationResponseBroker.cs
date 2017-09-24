using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.TrinityServer.Avatar;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.OperationResponseHandler
{
    class DeviceAvatarOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public DeviceAvatarOperationResponseBroker() : base(typeof(DeviceAvatarOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)DeviceAvatarOperationResponseParameterCode.DeviceId];
                int avatarId = (int)parameters[(byte)DeviceAvatarOperationResponseParameterCode.AvatarId];
                AvatarOperationCode resolvedOperationCode = (AvatarOperationCode)parameters[(byte)DeviceAvatarOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)DeviceAvatarOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)DeviceAvatarOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceAvatarOperationResponseParameterCode.Parameters];
                TerminalDevice device;
                if (DeviceFactory.Instance.Find(deviceId, out device))
                {
                    AvatarOperationResponseApi.SendOperationResponse(device, avatarId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters);
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
