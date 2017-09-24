using Door_of_Soul.Communication.Protocol.External.Soul;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint;
using Door_of_Soul.Communication.Protocol.Internal.EndPoint.OperationResponseParameter;
using Door_of_Soul.Communication.TrinityServer.Soul;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.TrinityServer.EndPoint.OperationResponseHandler
{
    class DeviceSoulOperationResponseBroker : OperationResponseHandler<EndPointOperationCode>
    {
        public DeviceSoulOperationResponseBroker() : base(typeof(DeviceSoulOperationResponseParameterCode))
        {
        }

        public override bool Handle(EndPointOperationCode operationCode, OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(operationCode, returnCode, operationMessage, parameters, out errorMessage))
            {
                int deviceId = (int)parameters[(byte)DeviceSoulOperationResponseParameterCode.DeviceId];
                int soulId = (int)parameters[(byte)DeviceSoulOperationResponseParameterCode.SoulId];
                SoulOperationCode resolvedOperationCode = (SoulOperationCode)parameters[(byte)DeviceSoulOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)DeviceSoulOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)DeviceSoulOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceSoulOperationResponseParameterCode.Parameters];
                TerminalDevice device;
                if (DeviceFactory.Instance.Find(deviceId, out device))
                {
                    SoulOperationResponseApi.SendOperationResponse(device, soulId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters);
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
