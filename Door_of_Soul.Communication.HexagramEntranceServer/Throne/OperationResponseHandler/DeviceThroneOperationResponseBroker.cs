using Door_of_Soul.Communication.HexagramEntranceServer.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationResponseParameter;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.OperationResponseHandler
{
    class DeviceThroneOperationResponseBroker : BasicOperationResponseHandler
    {
        public DeviceThroneOperationResponseBroker() : base(typeof(DeviceThroneOperationResponseParameterCode))
        {
        }

        public override OperationReturnCode Handle(OperationReturnCode returnCode, string operationMessage, Dictionary<byte, object> parameters, out string errorMessage)
        {
            returnCode = base.Handle(returnCode, operationMessage, parameters, out errorMessage);
            if (returnCode == OperationReturnCode.Successiful)
            {
                int endPointId = (int)parameters[(byte)DeviceThroneOperationResponseParameterCode.EndPointId];
                int deviceId = (int)parameters[(byte)DeviceThroneOperationResponseParameterCode.DeviceId];
                DeviceThroneOperationCode resolvedOperationCode = (DeviceThroneOperationCode)parameters[(byte)DeviceThroneOperationResponseParameterCode.OperationCode];
                OperationReturnCode resolvedOperationReturnCode = (OperationReturnCode)parameters[(byte)DeviceThroneOperationResponseParameterCode.OperationReturnCode];
                string resolvedOperationMessage = (string)parameters[(byte)DeviceThroneOperationResponseParameterCode.OperationMessage];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceThroneOperationResponseParameterCode.Parameters];
                TerminalEndPoint endPoint;
                if (EndPointFactory.Instance.Find(endPointId, out endPoint))
                {
                    returnCode = DeviceThroneOperationResponseRouter.Instance.Route(endPoint, deviceId, resolvedOperationCode, resolvedOperationReturnCode, resolvedOperationMessage, resolvedParameters, out errorMessage);
                }
                else
                {
                    errorMessage = $"Can not find EndPointId:{endPointId} DeviceId:{deviceId}";
                    returnCode = OperationReturnCode.NotExisted;
                }
            }
            return returnCode;
        }
    }
}
