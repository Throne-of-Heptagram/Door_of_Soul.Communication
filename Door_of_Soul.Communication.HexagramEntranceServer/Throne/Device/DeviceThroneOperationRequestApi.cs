using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device.OperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne.Device
{
    public static class DeviceThroneOperationRequestApi
    {
        public static void SendOperationRequest(int endPointId, int deviceId, DeviceThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            ThroneOperationRequestApi.SendDeviceOperationRequest(endPointId, deviceId, operationCode, parameters);
        }

        public static void Register(int endPointId, int deviceId, string answerName, string basicPassword)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)RegisterRequestParameterCode.AnswerName, answerName },
                { (byte)RegisterRequestParameterCode.BasicPassword, basicPassword }
            };
            SendOperationRequest(endPointId, deviceId, DeviceThroneOperationCode.Register, operationRequestParameters);
        }
    }
}
