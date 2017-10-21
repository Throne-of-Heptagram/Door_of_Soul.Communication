using Door_of_Soul.Communication.Protocol.External.Avatar;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.TrinityServer.Avatar;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.OperationResponseHandler
{
    class DeviceAvatarOperationResponseBroker : BasicOperationResponseHandler
    {
        public DeviceAvatarOperationResponseBroker() : base(typeof(DeviceAvatarOperationResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
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
                }
                else
                {
                    errorMessage = $"Can not find DeviceId:{deviceId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
