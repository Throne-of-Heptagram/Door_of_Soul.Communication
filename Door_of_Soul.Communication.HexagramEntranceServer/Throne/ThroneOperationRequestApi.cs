using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.EndPoint;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationRequestParameter;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramEntranceServer.Throne
{
    public static class ThroneOperationRequestApi
    {
        public static void SendOperationRequest(ThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            ThroneCommunicationService.Instance.SendOperation(operationCode, parameters);
        }

        public static void SendEndPointOperationRequest(int endPointId, EndPointThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)EndPointThroneOperationRequestParameterCode.EndPointId, endPointId },
                { (byte)EndPointThroneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)EndPointThroneOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(ThroneOperationCode.EndPointThroneOperation, operationRequestParameters);
        }

        public static void SendDeviceOperationRequest(int endPointId, int deviceId, DeviceThroneOperationCode operationCode, Dictionary<byte, object> parameters)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)DeviceThroneOperationRequestParameterCode.EndPointId, endPointId },
                { (byte)DeviceThroneOperationRequestParameterCode.DeviceId, deviceId },
                { (byte)DeviceThroneOperationRequestParameterCode.OperationCode, operationCode },
                { (byte)DeviceThroneOperationRequestParameterCode.Parameters, parameters }
            };
            SendOperationRequest(ThroneOperationCode.DeviceThroneOperation, operationRequestParameters);
        }

        public static void GetAnswerTrinityServer(int answerId)
        {
            Dictionary<byte, object> operationRequestParameters = new Dictionary<byte, object>
            {
                { (byte)GetAnswerTrinityServerRequestParameterCode.AnswerId, answerId }
            };
            SendOperationRequest(ThroneOperationCode.GetAnswerTrinityServer, operationRequestParameters);
        }
    }
}
