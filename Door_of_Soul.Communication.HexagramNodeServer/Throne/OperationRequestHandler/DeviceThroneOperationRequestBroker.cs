using Door_of_Soul.Communication.HexagramNodeServer.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.Device;
using Door_of_Soul.Communication.Protocol.Hexagram.Throne.OperationRequestParameter;
using Door_of_Soul.Core.HexagramNodeServer;
using Door_of_Soul.Core.Protocol;
using System.Collections.Generic;

namespace Door_of_Soul.Communication.HexagramNodeServer.Throne.OperationRequestHandler
{
    class DeviceThroneOperationRequestBroker : SubjectOperationRequestHandler<TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode>, VirtualThrone, ThroneOperationCode>
    {
        public DeviceThroneOperationRequestBroker() : base(typeof(DeviceThroneOperationRequestParameterCode))
        {
        }

        public override void SendResponse(TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode> terminal, VirtualThrone target, ThroneOperationCode operationCode, OperationReturnCode operationReturnCode, string operationMessage, Dictionary<byte, object> parameters)
        {
            ThroneOperationResponseApi.SendOperationResponse(terminal as ThroneHexagramEntrance, operationCode, operationReturnCode, operationMessage, parameters);
        }

        public override bool Handle(TerminalHexagramEntrance<ThroneEventCode, ThroneOperationCode> terminal, VirtualThrone requester, ThroneOperationCode operationCode, Dictionary<byte, object> parameters, out string errorMessage)
        {
            if (base.Handle(terminal, requester, operationCode, parameters, out errorMessage))
            {
                int endPointId = (int)parameters[(byte)DeviceThroneOperationRequestParameterCode.EndPointId];
                int deviceId = (int)parameters[(byte)DeviceThroneOperationRequestParameterCode.DeviceId];
                DeviceThroneOperationCode resolvedOperationCode = (DeviceThroneOperationCode)parameters[(byte)DeviceThroneOperationRequestParameterCode.OperationCode];
                Dictionary<byte, object> resolvedParameters = (Dictionary<byte, object>)parameters[(byte)DeviceThroneOperationRequestParameterCode.Parameters];
                return DeviceThroneOperationRequestRouter.Instance.Route(
                    terminal: terminal as ThroneHexagramEntrance,
                    l2TerminalId: endPointId,
                    l3TerminalId: deviceId,
                    subject: requester,
                    operationCode: resolvedOperationCode,
                    parameters: resolvedParameters,
                    errorMessage: out errorMessage);
            }
            else
            {
                return false;
            }
        }
    }
}
